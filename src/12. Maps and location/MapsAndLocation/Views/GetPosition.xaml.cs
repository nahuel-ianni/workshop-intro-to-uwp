using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MapsAndLocation.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GetPosition : Page
    {
        public GetPosition()
        {
            this.InitializeComponent();
        }

        // Captures the value entered by user. 
        private uint _desireAccuracyInMetersValue = 0;
        private CancellationTokenSource cts = null;

        /// <summary> 
        /// Invoked when this page is about to be displayed in a Frame. 
        /// </summary> 
        /// <param name="e">Event data that describes how this page was reached. The Parameter 
        /// property is typically used to configure the page.</param> 
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            GetGeolocationButton.IsEnabled = true;
            CancelGetGeolocationButton.IsEnabled = false;
            DesiredAccuracyInMeters.IsEnabled = true;
        }

        /// <summary> 
        /// Invoked immediately before the Page is unloaded and is no longer the current source of a parent Frame. 
        /// </summary> 
        /// <param name="e"> 
        /// Event data that can be examined by overriding code. The event data is representative 
        /// of the navigation that will unload the current Page unless canceled. The 
        /// navigation can potentially be canceled by setting e.Cancel to true. 
        /// </param> 
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
                cts = null;
            }

            base.OnNavigatingFrom(e);
        }

        /// <summary> 
        /// This is the click handler for the 'getGeolocation' button. 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        async private void GetGeolocationButtonClicked(object sender, RoutedEventArgs e)
        {
            GetGeolocationButton.IsEnabled = false;
            CancelGetGeolocationButton.IsEnabled = true;
            LocationDisabledMessage.Visibility = Visibility.Collapsed;

            try
            {
                // Request permission to access location 
                var accessStatus = await Geolocator.RequestAccessAsync();
                
                switch (accessStatus)
                {
                    case GeolocationAccessStatus.Allowed:
                        // Get cancellation token 
                        cts = new CancellationTokenSource();
                        CancellationToken token = cts.Token;

                        this.StatusTextBlock.Text = "Waiting for update...";

                        // If DesiredAccuracy or DesiredAccuracyInMeters are not set (or value is 0), DesiredAccuracy.Default is used. 
                        Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = _desireAccuracyInMetersValue };

                        // Carry out the operation 
                        Geoposition pos = await geolocator.GetGeopositionAsync().AsTask(token);

                        UpdateLocationData(pos);
                        this.StatusTextBlock.Text = "Location updated.";
                        break;

                    case GeolocationAccessStatus.Denied:
                        this.StatusTextBlock.Text = "Access to location is denied.";
                        LocationDisabledMessage.Visibility = Visibility.Visible;
                        UpdateLocationData(null);
                        break;

                    case GeolocationAccessStatus.Unspecified:
                        this.StatusTextBlock.Text = "Unspecified error.";
                        UpdateLocationData(null);
                        break;
                }
            }
            catch (TaskCanceledException)
            {
                this.StatusTextBlock.Text = "Canceled.";
            }
            catch (Exception ex)
            {
                this.StatusTextBlock.Text = ex.ToString();
            }
            finally
            {
                cts = null;
            }

            GetGeolocationButton.IsEnabled = true;
            CancelGetGeolocationButton.IsEnabled = false;
        }

        /// <summary> 
        /// This is the click handler for the 'CancelGetGeolocation' button. 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        private void CancelGetGeolocationButtonClicked(object sender, RoutedEventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
                cts = null;
            }

            GetGeolocationButton.IsEnabled = true;
            CancelGetGeolocationButton.IsEnabled = false;
        }

        void DesiredAccuracyInMeters_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // Update with the value entered by user 
                _desireAccuracyInMetersValue = uint.Parse(DesiredAccuracyInMeters.Text);

                // Enable the button and clear out status message 
                GetGeolocationButton.IsEnabled = true;
                this.StatusTextBlock.Text = string.Empty;
            }
            catch (ArgumentNullException)
            {
                GetGeolocationButton.IsEnabled = false;
            }
            catch (FormatException)
            {
                this.StatusTextBlock.Text = "Desired Accuracy must be a number";
                GetGeolocationButton.IsEnabled = false;
            }
            catch (OverflowException)
            {
                this.StatusTextBlock.Text = "Desired Accuracy is out of bounds";
                GetGeolocationButton.IsEnabled = false;
            }
        }

        /// <summary> 
        /// Updates the user interface with the Geoposition data provided 
        /// </summary> 
        /// <param name="position">Geoposition to display its details</param> 
        private void UpdateLocationData(Geoposition position)
        {
            if (position == null)
            {
                ScenarioOutput_Latitude.Text = "No data";
                ScenarioOutput_Longitude.Text = "No data";
                ScenarioOutput_Accuracy.Text = "No data";
                ScenarioOutput_Source.Text = "No data";
                ShowSatalliteData(false);
            }
            else
            {
                ScenarioOutput_Latitude.Text = position.Coordinate.Point.Position.Latitude.ToString();
                ScenarioOutput_Longitude.Text = position.Coordinate.Point.Position.Longitude.ToString();
                ScenarioOutput_Accuracy.Text = position.Coordinate.Accuracy.ToString();
                ScenarioOutput_Source.Text = position.Coordinate.PositionSource.ToString();

                if (position.Coordinate.PositionSource == PositionSource.Satellite)
                {
                    // Show labels and satellite data when available 
                    ScenarioOutput_PosPrecision.Text = position.Coordinate.SatelliteData.PositionDilutionOfPrecision.ToString();
                    ScenarioOutput_HorzPrecision.Text = position.Coordinate.SatelliteData.HorizontalDilutionOfPrecision.ToString();
                    ScenarioOutput_VertPrecision.Text = position.Coordinate.SatelliteData.VerticalDilutionOfPrecision.ToString();
                    ShowSatalliteData(true);
                }
                else
                {
                    // Hide labels and satellite data 
                    ShowSatalliteData(false);
                }
            }
        }

        private void ShowSatalliteData(bool isVisible)
        {
            var visibility = isVisible ? Visibility.Visible : Visibility.Collapsed;
            ScenarioOutput_PosPrecision.Visibility = visibility;
            ScenarioOutput_HorzPrecision.Visibility = visibility;
            ScenarioOutput_VertPrecision.Visibility = visibility;
        }
    }
}
