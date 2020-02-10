using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UserInterfaceControls.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MasterDetailPage : Page
    {
        public MasterDetailPage()
        {
            this.InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ((Selector)sender).SelectedItem as ListViewItem;

            if (selectedItem != null)
            {
                this.contentTextBlock.Text = "Selected option: " + selectedItem.Name;

                switch (selectedItem.Name)
                {
                    case "Item1":
                        this.contentControl.Content = new NavPanePage();
                        break;

                    case "Item2":
                        this.contentControl.Content = new TabsAndPivotsPage();
                        break;

                    case "Item3":
                        this.contentControl.Content = new HubPage();
                        break;

                    default:
                        this.contentControl.Content = null;
                        break;
                }
            }
        }
    }
}
