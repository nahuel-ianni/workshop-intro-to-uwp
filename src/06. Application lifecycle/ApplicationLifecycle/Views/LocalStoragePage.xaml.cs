using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ApplicationLifecycle.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LocalStoragePage : Page
    {
        public LocalStoragePage()
        {
            this.InitializeComponent();
            App.Current.Suspending += Current_Suspending;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.SuspensionHolderTextBox.Text = !string.IsNullOrEmpty(e.Parameter.ToString()) ? e.Parameter.ToString() : App.Current.ToString();
            this.LocalFolderTextBlock.Text = "I store things on the following path: " + ApplicationData.Current.LocalFolder.Path;
        }

        private void Current_Suspending(object sender, Windows.ApplicationModel.SuspendingEventArgs e)
        {
            // Gets the navigation history, including parameters.
            var state = this.Frame.GetNavigationState();

            // Get a storage manager for the local storage system.
            var localSettings = ApplicationData.Current.LocalSettings;

            // Store the desired values.
            localSettings.Values["NavigationState"] = state;
        }
    }
}
