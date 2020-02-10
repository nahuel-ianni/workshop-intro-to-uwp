using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WebBrowser
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

        public Helpers.Library Library = new Helpers.Library();

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Library.Back(ref Display);
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            Library.Forward(ref Display);
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Display.Refresh();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            Display.Stop();
        }

        private void Go_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            Library.Go(ref Display, Value.Text, e);
        }

        private void Web_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            if (args.IsSuccess)
            {
                Value.Text = args.Uri.ToString();
            }
        }
    }
}
