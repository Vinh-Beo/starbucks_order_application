using System;
using System.Windows.Input;
using Common;

namespace Common
{
    public class WebDetailViewModel : ViewModelBase
    {
        #region Common Prop
        private bool _isBusy = false;
        public bool IsBusy { get => _isBusy; set { _isBusy = value; OnPropertyChanged("IsBusy"); } }
        private string _respMessage = "";
        public string ResponseMessage { get => _respMessage; set { _respMessage = value; OnPropertyChanged("ResponseMessage"); } }
        private bool _respOK = true;
        public bool ResponseOK { get => _respOK; set { _respOK = value; OnPropertyChanged("ResponseOK"); } }
        #endregion
        private string _Url;
        public string Url { get => _Url; set { _Url = value; OnPropertyChanged("Url"); } }

        private string _Title;
        public string Title { get => _Title; set { _Title = value; OnPropertyChanged("Title"); } }

        public Action DisplClose;
        public ICommand BackCmd
        {
            get
            {
                return new RelayCommand(new Action(async () =>
                {
                    DisplClose?.Invoke();
                }));
            }
        }
        public WebDetailViewModel()
        {
        }
    }
}
