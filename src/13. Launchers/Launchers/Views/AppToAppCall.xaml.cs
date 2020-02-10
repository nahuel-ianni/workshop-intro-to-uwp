using System;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Launchers.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppToAppCall : Page
    {
        public AppToAppCall()
        {
            this.InitializeComponent();
        }

        private async Task<string> LaunchAppForResults()
        {
            var testAppUri = new Uri("demo-sampleapp:"); // The protocol handled by the launched app
            var options = new LauncherOptions();

            // Remark: This has to be the family name of the launched app!
            options.TargetApplicationPackageFamilyName = "100a09f7-0848-4e0b-8f5e-b52b18d32783_15q9a6cr6qx7p";

            var inputData = new ValueSet();
            inputData["TestData"] = this.SendDataTextBlock.Text + " at " + DateTime.Now.ToString();

            string theResult = "";
            LaunchUriResult result = await Windows.System.Launcher.LaunchUriForResultsAsync(testAppUri, options, inputData);
            if (result.Status == LaunchUriStatus.Success &&
                result.Result != null &&
                result.Result.ContainsKey("ReturnedData"))
            {
                ValueSet theValues = result.Result;
                theResult = theValues["ReturnedData"] as string;
            }
            else
            {
                theResult = result.Status.ToString();
            }

            return theResult;
        }

        private async void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            string data = await this.LaunchAppForResults();
            this.ReturnedDataTextBlock.Text = data;
        }
    }
}
