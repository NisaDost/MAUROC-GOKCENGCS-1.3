using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS_UI.ViewModel
{
    class HomePageViewModel : ViewModelBase
    {
        private double _taskBarHeight = 40;
        private double _menuWidth = 200;
        public double TaskBarHeight
        {
            get { return _taskBarHeight; }
            set
            {
                _taskBarHeight = value;
                OnPropertyChanged("TaskBarHeight");
            }
        }
        public double MenuWidth
        {
            get { return _menuWidth; }
            set
            {
                _menuWidth = value;
                OnPropertyChanged("MenuWidth");
            }
        }
    }
}
