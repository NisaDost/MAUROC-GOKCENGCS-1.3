using System.IO;

namespace GCS_UI.ViewModel
{
    class HomePageViewModel : ViewModelBase
    {
        private string _mapUrl = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory).Split("bin")[0], "Resources", "MapPage.html");

        //public HomePageViewModel()
        //{
        //    string relativePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory).Split("bin")[0]);
        //    _mapUrl = Path.Combine(relativePath, "Resources", "MapPage.html");
        //}

        public string MapUrl
        {
            get { return _mapUrl; }
            set
            {
                _mapUrl = value;
                OnPropertyChanged("MapUrl");
            }
        }
    }
}
