using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Navigation.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NavigationPage : Page
    {
        public NavigationPage()
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            var navigationPageContentFormat = loader.GetString("NavigationPageContent");
            var navigationPageContentWhenEmpty = loader.GetString("NavigationPageContentWhenEmpty");
            var parameter = String.IsNullOrEmpty(e.Parameter?.ToString()) ? navigationPageContentWhenEmpty : e.Parameter?.ToString();

            this.ParameterTextBlock.Text = 
                String.Format(navigationPageContentFormat, parameter);
        }
    }
}
