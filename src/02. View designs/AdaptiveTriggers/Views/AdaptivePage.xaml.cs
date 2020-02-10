using AdaptiveTriggers.Models;
using System;
using System.Collections.ObjectModel;
using Windows.ApplicationModel.Calls;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
namespace AdaptiveTriggers.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdaptivePage : Page
    {
        public string WelcomeText { get { return "Adaptive page example"; } }

        public string WelcomeMobileText { get { return "Adaptive mobile page example"; } }

        public ObservableCollection<Contact> Contacts = new ObservableCollection<Contact>
        {
            new Contact("Jerry", "Nixon"),
            new Contact("Darren", "May"),
            new Contact("Bill", "Gates"),
            new Contact("Steve", "Jobs"),
            new Contact("Bruce", "Lee"),
            new Contact("Arnold", "Schwarzenegger"),
            new Contact("Sylvester", "Stallone"),
            new Contact("Rocky", "Balboa"),
            new Contact("Bruce", "Wayne"),
        };

        public AdaptivePage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            /// Checks if we are working on a phone and, if so; allows for extended functionality.
            /// Need to add the Mobile extensions.
            /// Need to add the Phone capability.
            //if (ApiInformation.IsApiContractPresent("Windows.Phone.PhoneContract", 1, 0))
            //{
            //    PhoneCallStore phoneCallStore = await PhoneCallManager.RequestStoreAsync();
            //    Guid lineId = await phoneCallStore.GetDefaultLineAsync();
            //    var line = await PhoneLine.FromIdAsync(lineId);

            //    if (line != null && line.CanDial)
            //    {
            //        Contact contact = (Contact)((Windows.UI.Xaml.Controls.Primitives.Selector)sender).SelectedItem;
            //        line.Dial(contact.PhoneNumber, contact.FullName);
            //    }
            //}
        }
    }
}
