using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Navigation.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EmptyNavigationPage : Page
    {
        public EmptyNavigationPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // Check to see if the frame has a navigation history for us to use.
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
    }
}
