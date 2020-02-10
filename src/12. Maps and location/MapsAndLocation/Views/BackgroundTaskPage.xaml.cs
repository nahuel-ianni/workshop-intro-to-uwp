using System;
using Windows.ApplicationModel.Background;
using Windows.Devices.Geolocation;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MapsAndLocation.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BackgroundTaskPage : Page
    {
        public BackgroundTaskPage()
        {
            this.InitializeComponent();
        }

        // For background task registration 
       private const string BackgroundTaskName = "LocationBackgroundTask"; 
       private const string BackgroundTaskEntryPoint = "BackgroundTask.LocationBackgroundTask"; 

       private IBackgroundTaskRegistration geolocTask = null; 

       /// <summary> 
       /// Invoked when this page is about to be displayed in a Frame. 
       /// </summary> 
       /// <param name="e">Event data that describes how this page was reached. The Parameter 
       /// property is typically used to configure the page.</param> 
       protected override void OnNavigatedTo(NavigationEventArgs e)
       { 
           // Loop through all background tasks to see if SampleBackgroundTaskName is already registered 
           foreach (var cur in BackgroundTaskRegistration.AllTasks) 
           { 
               if (cur.Value.Name == BackgroundTaskName) 
               { 
                   geolocTask = cur.Value; 
                   break; 
               } 
           } 

           if (geolocTask != null) 
           { 
               // Associate an event handler with the existing background task 
               geolocTask.Completed += OnCompleted; 

               try 
               { 
                   BackgroundAccessStatus backgroundAccessStatus = BackgroundExecutionManager.GetAccessStatus(); 
                    
                   switch (backgroundAccessStatus) 
                   { 
                       case BackgroundAccessStatus.Unspecified: 
                       case BackgroundAccessStatus.Denied: 
                           this.StatusTextBlock.Text = "Not able to run in background. Application must be added to the lock screen."; 
                           break; 


                       default: 
                           this.StatusTextBlock.Text = "Background task is already registered. Waiting for next update..."; 
                           break; 
                   } 
               } 
               catch (Exception ex) 
               { 
                   this.StatusTextBlock.Text = ex.ToString(); 
               } 
               UpdateButtonStates(/*registered:*/ true); 
           } 
           else 
           { 
               UpdateButtonStates(/*registered:*/ false); 
           } 
       } 


       /// <summary> 
       /// Invoked immediately before the Page is unloaded and is no longer the current source of a parent Frame. 
       /// </summary> 
       /// <param name="e"> 
       /// Event data that can be examined by overriding code. The event data is representative 
       /// of the navigation that will unload the current Page unless canceled. The 
       /// navigation can potentially be canceled by setting e.Cancel to true. 
       /// </param> 
       protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
       { 
            if (geolocTask != null) 
            { 
                // Remove the event handler 
                geolocTask.Completed -= OnCompleted; 
            } 
            base.OnNavigatingFrom(e); 
        } 

        /// <summary> 
        /// This is the click handler for the 'Register' button. 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        async private void RegisterBackgroundTask(object sender, RoutedEventArgs e)
        { 
            try 
            { 
                // Get permission for a background task from the user. If the user has already answered once, 
                // this does nothing and the user must manually update their preference via PC Settings. 
                BackgroundAccessStatus backgroundAccessStatus = await BackgroundExecutionManager.RequestAccessAsync(); 
                
                // Regardless of the answer, register the background task. If the user later adds this application 
                // to the lock screen, the background task will be ready to run. 
                // Create a new background task builder 
                BackgroundTaskBuilder geolocTaskBuilder = new BackgroundTaskBuilder(); 
                
                geolocTaskBuilder.Name = BackgroundTaskName; 
                geolocTaskBuilder.TaskEntryPoint = BackgroundTaskEntryPoint; 
                
                // Create a new timer triggering at a 15 minute interval 
                var trigger = new TimeTrigger(15, false); 
                
                // Associate the timer trigger with the background task builder 
                geolocTaskBuilder.SetTrigger(trigger); 
                
                // Register the background task 
                geolocTask = geolocTaskBuilder.Register(); 
                
                // Associate an event handler with the new background task 
                geolocTask.Completed += OnCompleted; 
                
                UpdateButtonStates(/*registered*/ true); 
                
                switch (backgroundAccessStatus) 
                { 
                    case BackgroundAccessStatus.Unspecified: 
                    case BackgroundAccessStatus.Denied: 
                        this.StatusTextBlock.Text = "Not able to run in background. Application must be added to the lock screen."; 
                        break; 
                        
                    default: 
                        // BckgroundTask is allowed 
                        this.StatusTextBlock.Text = "Background task registered."; 

                        // Need to request access to location 
                        // This must be done with the background task registeration 
                        // because the background task cannot display UI. 
                        RequestLocationAccess(); 
                        break; 
                } 
            } 
            catch (Exception ex) 
            { 
                this.StatusTextBlock.Text = ex.ToString(); 
                UpdateButtonStates(/*registered:*/ false); 
            } 
        } 
        
        /// <summary> 
        /// Get permission for location from the user. If the user has already answered once, 
        /// this does nothing and the user must manually update their preference via Settings. 
        /// </summary> 
        private async void RequestLocationAccess()
        { 
            // Request permission to access location 
            var accessStatus = await Geolocator.RequestAccessAsync(); 

            switch (accessStatus) 
            { 
                case GeolocationAccessStatus.Allowed: 
                    break; 

                case GeolocationAccessStatus.Denied: 
                    this.StatusTextBlock.Text = "Access to location is denied."; 
                    break; 

                case GeolocationAccessStatus.Unspecified: 
                    this.StatusTextBlock.Text = "Unspecificed error!"; 
                    break; 
            } 
        } 

        /// <summary> 
        /// This is the click handler for the 'Unregister' button. 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        private void UnregisterBackgroundTask(object sender, RoutedEventArgs e)
        { 
            // Unregister the background task 
            if (null != geolocTask) 
            { 
                geolocTask.Unregister(true); 
                geolocTask = null; 
            } 

            ScenarioOutput_Latitude.Text = "No data"; 
            ScenarioOutput_Longitude.Text = "No data"; 
            ScenarioOutput_Accuracy.Text = "No data"; 
            UpdateButtonStates(/*registered:*/ false); 
            this.StatusTextBlock.Text = "Background task unregistered"; 
        } 
        
        /// <summary> 
        /// Event handle to be raised when the background task is completed 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        private async void OnCompleted(IBackgroundTaskRegistration sender, BackgroundTaskCompletedEventArgs e)
        { 
            if (sender != null) 
            { 
                // Update the UI with progress reported by the background task 
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                { 
                    try 
                    { 
                        // If the background task threw an exception, display the exception in 
                        // the error text box. 
                        e.CheckResult(); 

                        // Update the UI with the completion status of the background task 
                        // The Run method of the background task sets this status.  
                        var settings = ApplicationData.Current.LocalSettings; 
                        if (settings.Values["Status"] != null) 
                        { 
                            this.StatusTextBlock.Text = settings.Values["Status"].ToString(); 
                        } 
                        
                        // Extract and display location data set by the background task if not null 
                        ScenarioOutput_Latitude.Text = (settings.Values["Latitude"] == null) ? "No data" : settings.Values["Latitude"].ToString(); 
                        ScenarioOutput_Longitude.Text = (settings.Values["Longitude"] == null) ? "No data" : settings.Values["Longitude"].ToString(); 
                        ScenarioOutput_Accuracy.Text = (settings.Values["Accuracy"] == null) ? "No data" : settings.Values["Accuracy"].ToString(); 
                    } 
                    catch (Exception ex) 
                    { 
                        // The background task had an error 
                        this.StatusTextBlock.Text = ex.ToString(); 
                    } 
                }); 
            } 
        } 
        
        /// <summary> 
        /// Update the enable state of the register/unregister buttons. 
        ///  
        private async void UpdateButtonStates(bool registered)
        { 
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                () =>
                { 
                    RegisterBackgroundTaskButton.IsEnabled = !registered; 
                    UnregisterBackgroundTaskButton.IsEnabled = registered; 
                }); 
        } 
    }
}
