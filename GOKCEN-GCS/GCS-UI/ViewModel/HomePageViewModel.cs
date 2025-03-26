using System.IO;
using System.Windows.Input;
using Microsoft.Web.WebView2.Wpf;
using GCS_UI.Command;
using System.Globalization;

namespace GCS_UI.ViewModel
{
    class HomePageViewModel : ViewModelBase
    {
        private string _latitude = "39.9255";  // Default center latitude (Ankara, Türkiye) - stored as string for textbox usage
        private string _longitude = "32.8663"; // Default center longitude (Ankara, Türkiye) - stored as string for textbox usage
        private string _mapUrl; // = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory).Split("bin")[0], "Resources", "MapPage.html");
        public ICommand UpdateMapCommand { get; }

        public HomePageViewModel()
        {
            string relativePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory).Split("bin")[0];
            _mapUrl = Path.Combine(relativePath, "Resources", "MapPage.html");

            UpdateMapCommand = new RelayCommand(UpdateMap);
        }
        public string Latitude
        {
            get => _latitude;
            set
            {
                _latitude = value;
                OnPropertyChanged(nameof(Latitude));
            }
        }
        public string Longitude
        {
            get => _longitude;
            set
            {
                _longitude = value;
                OnPropertyChanged(nameof(Longitude));
            }
        }
        public string MapUrl
        {
            get { return _mapUrl; }
            set
            {
                _mapUrl = value;
                OnPropertyChanged("MapUrl");
            }
        }

        private void UpdateMap()
        {
            if (WebViewInstance?.CoreWebView2 != null)
            {
                // Convert strings to double safely
                if (double.TryParse(Latitude, NumberStyles.Float, CultureInfo.InvariantCulture, out double lat) &&
                    double.TryParse(Longitude, NumberStyles.Float, CultureInfo.InvariantCulture, out double lng))
                {
                    // Ensure the numbers are formatted with '.' as a decimal separator
                    string latStr = lat.ToString(CultureInfo.InvariantCulture);
                    string lngStr = lng.ToString(CultureInfo.InvariantCulture);

                    // Execute JavaScript to update the map
                    string script = $"map.setView([{latStr}, {lngStr}], 15);";
                    WebViewInstance.CoreWebView2.ExecuteScriptAsync(script);
                }
            }
        }

        private WebView2 _webViewInstance;
        public WebView2 WebViewInstance
        {
            get => _webViewInstance;
            set
            {
                _webViewInstance = value;
                OnPropertyChanged(nameof(WebViewInstance));
            }
        }
    }
}
