using System;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Launchers.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UwpAppCall : Page
    {
        public UwpAppCall()
        {
            this.InitializeComponent();
            this.AppTextBox.Text = @"bingmaps:?where=1600%20Pennsylvania%20Ave,%20Washington,%20DC";
        }

        private async void Map_Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // Center on White house by default.
            var uriNewYork = new Uri(this.AppTextBox.Text);
            //@"bingmaps:?where=1600%20Pennsylvania%20Ave,%20Washington,%20DC"
            //@"bingmaps:?rtp=pos.44.9160_-110.4158~pos.45.0475_-109.4187"

            // Launch the Windows Maps app
            var launcherOptions = new Windows.System.LauncherOptions();
            launcherOptions.TargetApplicationPackageFamilyName = "Microsoft.WindowsMaps_8wekyb3d8bbwe";
            var success = await Windows.System.Launcher.LaunchUriAsync(uriNewYork, launcherOptions);

            this.ResultTextBlock.Text = success.ToString();
        }

        private async void App_Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // The URI to launch
            var uri = new Uri(this.AppTextBox.Text);
            //@"http://www.bing.com"
            //"ms-call:settings"

            // Set the option to show a warning
            var promptOptions = new Windows.System.LauncherOptions();
            promptOptions.TreatAsUntrusted = true;

            // Launch the URI
            var success = await Windows.System.Launcher.LaunchUriAsync(uri, promptOptions);

            this.ResultTextBlock.Text = success.ToString();
        }
    }
}
