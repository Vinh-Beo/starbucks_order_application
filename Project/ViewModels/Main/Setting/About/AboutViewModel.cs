using Common;
using Project.Language;
using S3WAN.Views.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Project.ViewModels.Main.Setting.About
{
    class AboutViewModel: ViewModelBase
    {
        #region Common prop
        private bool isBusy = false;
        public bool IsBusy { get => isBusy; set { isBusy = value; OnPropertyChanged("IsBusy"); } }
        private bool responseOK;
        public bool ResponseOK { get => responseOK; set { responseOK = value; OnPropertyChanged("ResponseOK"); } }
        private string responseMessage;
        public string ResponseMessage { get => responseMessage; set { responseMessage = value; OnPropertyChanged("ResponseMessage"); } }
        #endregion

        private string _versionStr;
        public string VersionStr { get => _versionStr; set { _versionStr = value; OnPropertyChanged("VersionStr"); } }
        private string _webStr;
        public string WebStr { get => _webStr; set { _webStr = value; OnPropertyChanged("WebStr"); } }
        private string _emailStr;
        public string EmailStr { get => _emailStr; set { _emailStr = value; OnPropertyChanged("EmailStr"); } }
        private string _hotLineStr;
        public string HotLineStr { get => _hotLineStr; set { _hotLineStr = value; OnPropertyChanged("HotLineStr"); } }

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

        public ICommand OpenWebCmd
        {
            get
            {
                return new RelayCommand(new Action(async () =>
                {
                    // Display new popup
                    WebDetailViewModel _vm = new WebDetailViewModel()
                    {
                        IsBusy = true,
                        ResponseMessage = "",
                        ResponseOK = true,
                        Url = WebStr,
                        Title = AppResources.Website,
                        DisplClose = new Action(() =>
                        {
                            Application.Current.MainPage.Navigation.PopModalAsync();
                        })
                    };
                    WebDetailView _p = new WebDetailView()
                    {
                        BindingContext = _vm
                    };
                    await Application.Current.MainPage.Navigation.PushModalAsync(_p);
                }));
            }
        }
    }
}
