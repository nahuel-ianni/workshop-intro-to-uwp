using System;
using Windows.Phone.Devices.Notification;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PhoneVibration
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        ///  Need to add the Mobile extension for this to work.
        /// </summary>
        VibrationDevice testVibrationDevice = VibrationDevice.GetDefault();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void VibrateButton_Click(object sender, RoutedEventArgs e)
        {
            int vibrationDuration = 0;
            Int32.TryParse(this.VibrateTextBox.Text, out vibrationDuration);

            testVibrationDevice.Vibrate(TimeSpan.FromSeconds(vibrationDuration));
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            testVibrationDevice.Cancel();
        }
    }
}
