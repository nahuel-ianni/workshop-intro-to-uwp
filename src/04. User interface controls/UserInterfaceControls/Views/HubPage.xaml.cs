using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UserInterfaceControls.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HubPage : Page
    {
        public HubPage()
        {
            this.InitializeComponent();
        }

        private async void Hub_SectionHeaderClick(object sender, HubSectionHeaderClickEventArgs e)
        {
            switch (e.Section.Name)
            {
                case "NavigateSection":
                    await this.DoStuff();
                    break;

                default:
                    break;
            }
        }

        private async Task<ContentDialogResult> DoStuff()
        {
            var noWifiDialog = new ContentDialog()
            {
                Title = "Title",
                Content = "Content",
                PrimaryButtonText = "PrimaryButtonText"
            };

            return await noWifiDialog.ShowAsync();
        }
    }
}
