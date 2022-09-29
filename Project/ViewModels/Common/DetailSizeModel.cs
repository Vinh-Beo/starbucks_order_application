using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.ViewModels.Common
{
    public class DetailSizeModel : ViewModelBase
    {
        private string _Image;
        public string Image { get => _Image; set { _Image = value; OnPropertyChanged("Image"); } }
        private SizeEnum _Size;
        public SizeEnum Size { get => _Size; set { _Size = value; OnPropertyChanged("Size"); } }
        private bool _IsSelected = false;
        public bool IsSelected { get => _IsSelected; set { _IsSelected = value; OnPropertyChanged("IsSelected"); } }
    }
}
