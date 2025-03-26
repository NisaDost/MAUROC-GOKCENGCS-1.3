using System.Windows.Controls;
using Microsoft.Web.WebView2.Wpf;
using GCS_UI.ViewModel;

namespace GCS_UI.Components
{
    public partial class CollapseMenu : UserControl
    {
        public CollapseMenu()
        {
            InitializeComponent();
            var viewModel = new HomePageViewModel();
            DataContext = viewModel;
        }

        private void MapWebView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is HomePageViewModel viewModel)
            {
                viewModel.WebViewInstance = (WebView2)sender;
            }
        }
    }
}
