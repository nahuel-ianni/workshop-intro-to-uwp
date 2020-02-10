using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Navigation
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

        private void NavigationNoArgButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Navigate(null);
        }

        private void NavigationWithArgButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Navigate(this.ArgumentTextBox.Text);
        }

        private void Navigate(object obj)
        {
            if (obj != null)
            {
                this.Frame.Navigate(typeof(Views.NavigationPage), obj);
            }
            else
            {
                this.Frame.Navigate(typeof(Views.EmptyNavigationPage));
            }
        }
    }
}
