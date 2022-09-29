using System;
using System.Windows.Input;
using Common;

namespace S3WAN.ViewModels.Login.Help
{
    public class HelpViewModel : ViewModelBase
    {
        private string _Website;
        public string Website { get => _Website; set { _Website = value; OnPropertyChanged("Website"); } }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged("Email"); } }

        private string _Hotline;
        public string Hotline { get => _Hotline; set { _Hotline = value; OnPropertyChanged("Hotline"); } }

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
        public HelpViewModel()
        {
        }
    }
}
