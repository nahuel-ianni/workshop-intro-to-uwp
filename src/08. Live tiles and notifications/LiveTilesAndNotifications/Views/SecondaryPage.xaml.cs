using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Popups;
using Windows.UI.StartScreen;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LiveTilesAndNotifications.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SecondaryPage : Page
    {
        public SecondaryPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                var tileId = "SecondaryPageId";
                var displayName = "SecondaryPageName";
                var tileActivatedArguments = "SecondaryPageArguments";
                var iconUri = "ms-appx:///Assets/Wide310x150Logo.scale-200.png";

                // Create a secondary tile with all possible info.
                var secondaryTile = new SecondaryTile(
                    tileId, 
                    displayName, 
                    tileActivatedArguments, 
                    new Uri(iconUri), 
                    TileSize.Square150x150);

                // Adaptive code to modify the look of the secondary tile when not on WP.
                if (!ApiInformation.IsTypePresent("Windows.Phone.Ui.Input.HardwareButtons"))
                {
                    secondaryTile.VisualElements.ShowNameOnSquare150x150Logo = true;
                    secondaryTile.VisualElements.ShowNameOnWide310x150Logo = true;
                    secondaryTile.VisualElements.ShowNameOnSquare310x310Logo = true;
                }

                if (!ApiInformation.IsTypePresent("Windows.Phone.Ui.Input.HardwareButtons"))
                {
                    // Once the process is finished, we get the status message.
                    bool isPinned = await secondaryTile.RequestCreateAsync();

                    if (isPinned)
                    {
                        var dialog = new MessageDialog("Pin successful");
                        await dialog.ShowAsync();
                    }
                    else
                    {
                        var dialog = new MessageDialog("Pin unsuccessful");
                        await dialog.ShowAsync();
                    }
                }
                else
                {
                    await secondaryTile.RequestCreateAsync();
                }
            }
        }
    }
}
