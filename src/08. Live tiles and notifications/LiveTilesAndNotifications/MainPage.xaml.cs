using System;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LiveTilesAndNotifications
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var file = await this.GetPackagedFile("AdaptiveTiles", "UpdatePrimaryTileTemplate.xml");
            var xmlDoc = await Windows.Data.Xml.Dom.XmlDocument.LoadFromFileAsync(file);

            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            var tileNotification = new TileNotification(xmlDoc);
            updater.Update(tileNotification);
        }

        private void NavigateSecPageButton_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Views.SecondaryPage));
        }

        private async void ToastButton_Button_Click(object sender, RoutedEventArgs e)
        {
            var file = await this.GetPackagedFile("AdaptiveTiles", "Toast.xml");
            var xmlDoc = await Windows.Data.Xml.Dom.XmlDocument.LoadFromFileAsync(file);

            var toast = new ToastNotification(xmlDoc);
            var notifier = ToastNotificationManager.CreateToastNotifier();

            notifier.Show(toast);
        }

        private async Task<StorageFile> GetPackagedFile(string folderName, string fileName)
        {
            StorageFolder installFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;

            if (folderName != null)
            {
                StorageFolder subFolder = await installFolder.GetFolderAsync(folderName);
                return await subFolder.GetFileAsync(fileName);
            }
            else
            {
                return await installFolder.GetFileAsync(fileName);
            }
        }
    }
}
