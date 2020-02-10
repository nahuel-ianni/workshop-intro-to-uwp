using System;
using Windows.ApplicationModel.Activation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SampleApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.FamilyNameTextBox.Text = "Family name " + Windows.ApplicationModel.Package.Current.Id.FamilyName;
        }

        #region Launcher code
        /// Used to signal when this app is ready to return to the caller app.
        private Windows.System.ProtocolForResultsOperation operation = null;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is ProtocolForResultsActivatedEventArgs)
            {
                var protocolForResultsArgs = e.Parameter as ProtocolForResultsActivatedEventArgs;
                // Set the ProtocolForResultsOperation field.
                operation = protocolForResultsArgs.ProtocolForResultsOperation;

                if (protocolForResultsArgs.Data.ContainsKey("TestData"))
                {
                    this.ReceivedDataTextBlock.Text = protocolForResultsArgs.Data["TestData"] as string;
                }
            }
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (operation != null)
            {
                ValueSet result = new ValueSet();
                result["ReturnedData"] = "The returned result was at " + DateTime.Now.ToString();
                operation.ReportCompleted(result);
            }
        }
        #endregion
    }
}
