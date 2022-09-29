using System;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Common;
using Project.Language;

namespace S3WAN.ViewModels.Main.Setting.User
{
    public class ChangeUserInfoViewModel : ViewModelBase
    {
        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged("DisplayName"); } }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged("Email"); } }

        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged("Phone"); } }

        private UserModel _User;
        public UserModel User { get => _User; set { _User = value; OnPropertyChanged("User"); } }

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
        public ICommand OKCmd
        {
            get
            {
                return new RelayCommand(new Action(async () =>
                {
                    // Check empty
                    if (string.IsNullOrWhiteSpace(DisplayName))
                    {
                        UserDialogs.Instance.Toast(new ToastConfig(AppResources.PleaseInputDisplayName).SetIcon("Close_32px.png").SetMessageTextColor(Color.Red));
                        return;
                    }
                    DisplayName = DisplayName.Trim();
                    // Check special character
                    if (FormBase.HasSpecicalChar(DisplayName))
                    {
                        UserDialogs.Instance.Toast(new ToastConfig(AppResources.DoNotInputDisplayNameHasSpecialCharacter).SetIcon("Close_32px.png").SetMessageTextColor(Color.Red));
                        return;
                    }

                    // Checking special character
                    bool response = false;
                    using (UserDialogs.Instance.Loading(""))
                    {
                        response = true;
                        UserDialogs.Instance.HideLoading();
                        if (!response)
                        {
                            UserDialogs.Instance.Toast(new ToastConfig(AppResources.SorryUnknownError).SetIcon("Close_32px.png").SetMessageTextColor(Color.Red));
                            return;
                        }
                    }
                    // OK signed out
                    UserDialogs.Instance.Toast(new ToastConfig(AppResources.UpdateUserInfoIsOK).SetIcon("OK_32px.png").SetMessageTextColor(Color.WhiteSmoke));
                    if (BackCmd != null && BackCmd.CanExecute(null))
                    {
                        BackCmd.Execute(null);
                    }
                }));
            }
        }
        public ChangeUserInfoViewModel()
        {
        }
    }
}
