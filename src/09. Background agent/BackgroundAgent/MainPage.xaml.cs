using System;
using System.Collections.Generic;
using System.Linq;
using Windows.ApplicationModel.Background;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BackgroundAgent
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // List with our background task implementations.
        IList<Type> backgroundTasks = new List<Type>()
        {
            typeof(BackgroundTasks.SimpleBackgroundTask),
            typeof(BackgroundTasks.AsyncBackgroundTask),
        };

        public MainPage()
        {
            this.InitializeComponent();
            this.RegisterAllBackgroundTasks();

            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // Get a storage manager for the local storage system.
            var localSettings = ApplicationData.Current.LocalSettings;

            // Get the value of NavigationState, if any.
            var simpleBackgroundTask = localSettings.Values["SimpleBackgroundTask"];
            var asyncBackgroundTask = localSettings.Values["AsyncBackgroundTask"];

            if (simpleBackgroundTask != null)
                this.SimpleBackgroundTaskContent.Text = simpleBackgroundTask.ToString();

            if (asyncBackgroundTask != null)
                this.AsyncBackgroundTaskContent.Text = asyncBackgroundTask.ToString();
        }

        /// <summary>
        /// Suscribe to the OnCompleted method if the app needs to know a task was executed in 
        /// the foreground and finished by the time the app is launched.
        /// </summary>
        private async void OnCompleted(IBackgroundTaskRegistration task, BackgroundTaskCompletedEventArgs args)
        {
            var settings = ApplicationData.Current.LocalSettings;
            var key = task.Name.ToString();
            var message = settings.Values[key].ToString();

            this.MainPage_Loaded(this, null);
        }

        private async void RegisterAllBackgroundTasks()
        {
            /// Before registering the tasks, we must ask the OS permission
            /// to do so, and it may be approve or denied dependind on the
            /// user configuration.
            var background = await BackgroundExecutionManager.RequestAccessAsync();

            switch (background)
            {
                case BackgroundAccessStatus.Denied:
                    // Windows: Background activity and updates for this app are disabled by the user.
                    //
                    // Windows Phone: The maximum number of background apps allowed across the system has been reached or
                    // background activity and updates for this app are disabled by the user.
                    await new ContentDialog() { Title = "Info", Content = "Background task registration denied." }.ShowAsync();
                    break;

                case BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity:
                    // Windows: Added to list of background apps; set up background tasks; 
                    // can use the network connectivity broker.
                    //
                    // Windows Phone: This value is never used on Windows Phone.
                    break;

                case BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity:
                    // Windows: Added to list of background apps; set up background tasks;
                    // cannot use the network connectivity broker.
                    //
                    // Windows Phone: This app can register background tasks. Required for all 
                    // background tasks on Windows Phone.
                    break;

                case BackgroundAccessStatus.Unspecified:
                    // The user didn't explicitly disable or enable access and updates. 
                    break;
            }

            foreach (var item in this.backgroundTasks)
            {
                /// Ensure the task registration is performed only once.
                if (BackgroundTaskRegistration.AllTasks.Values.FirstOrDefault(task => task.Name == item.Name) == null)
                {
                    var task = this.RegisterTask(item, SystemTriggerType.TimeZoneChange);

                    /// Suscribe to the completed event of the task in case
                    /// the app should do some process when launched.
                    task.Completed += new BackgroundTaskCompletedEventHandler(OnCompleted);
                }
            }
        }

        private BackgroundTaskRegistration RegisterTask(
            Type taskType,
            SystemTriggerType systemTriggerType,
            SystemConditionType systemConditionType = SystemConditionType.Invalid)
        {
            var builder = new BackgroundTaskBuilder();

            /// A string identifier for the background task.
            builder.Name = taskType.Name;

            /// The entry point of the task.
            /// This HAS to be the full name of the background task: {Namespace}.{Class name}
            builder.TaskEntryPoint = taskType.FullName;

            /// The specific trigger event that will fire the task on our application.
            builder.SetTrigger(new SystemTrigger(systemTriggerType, false));

            /// A condition for the task to run.
            /// If specified, after the event trigger is fired, the OS will wait for
            /// the condition situation to happen before executing the task.
            if (systemConditionType != SystemConditionType.Invalid)
            {
                builder.AddCondition(new SystemCondition(systemConditionType));
            }

            /// Register the task and returns the registration output.
            return builder.Register();
        }
    }
}
