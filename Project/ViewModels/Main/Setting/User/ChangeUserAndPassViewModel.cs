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
    public class ChangeUserAndPassViewModel : ViewModelBase
    {
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged("UserName"); } }

        private string _OldPassword;
        public string OldPassword { get => _OldPassword; set { _OldPassword = value; OnPropertyChanged("OldPassword"); } }

        private string _NewPassword;
        public string NewPassword { get => _NewPassword; set { _NewPassword = value; OnPropertyChanged("NewPassword"); } }

        private string _ConfirmPassword;
        public string ConfirmNewPassword { get => _ConfirmPassword; set { _ConfirmPassword = value; OnPropertyChanged("ConfirmNewPassword"); } }

        private UserModel _User;
        public UserModel User { get => _User; set { _User = value; OnPropertyChanged("User"); } }

        public Action DisplClose;
        public Action DisplOK;
        public ICommand BackCmd
        {
            get
            {
                return new RelayCommand(new Action(() =>
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
                    if (string.IsNullOrWhiteSpace(UserName))
                    {
                        UserDialogs.Instance.Toast(new ToastConfig(AppResources.PleaseInputUserName).SetIcon("Close_32px.png").SetMessageTextColor(Color.Red));
                        return;
                    }
                    UserName = UserName.Trim();
                    // Check special character
                    if (FormBase.HasSpecicalChar(UserName))
                    {
                        UserDialogs.Instance.Toast(new ToastConfig(AppResources.DoNotInputUsernameHasSpecialCharacter).SetIcon("Close_32px.png").SetMessageTextColor(Color.Red));
                        return;
                    }
                    // Check empty
                    if (string.IsNullOrWhiteSpace(OldPassword))
                    {
                        UserDialogs.Instance.Toast(new ToastConfig(AppResources.PleaseInputOldPassword).SetIcon("Close_32px.png").SetMessageTextColor(Color.Red));
                        return;
                    }
                    OldPassword = OldPassword.Trim();
                    // Check special character
                    if (FormBase.HasPasswordSpecicalChar(OldPassword))
                    {
                        UserDialogs.Instance.Toast(new ToastConfig(AppResources.DoNotInputOldPasswordHasSpecialCharacter).SetIcon("Close_32px.png").SetMessageTextColor(Color.Red));
                        return;
                    }
                    // Check empty
                    if (string.IsNullOrWhiteSpace(NewPassword))
                    {
                        UserDialogs.Instance.Toast(new ToastConfig(AppResources.PleaseInputNewPassword).SetIcon("Close_32px.png").SetMessageTextColor(Color.Red));
                        return;
                    }
                    NewPassword = NewPassword.Trim();
                    // Check special character
                    if (FormBase.HasPasswordSpecicalChar(NewPassword))
                    {
                        UserDialogs.Instance.Toast(new ToastConfig(AppResources.DoNotInputNewPasswordHasSpecialCharacter).SetIcon("Close_32px.png").SetMessageTextColor(Color.Red));
                        return;
                    }
                    // Check empty
                    if (string.IsNullOrWhiteSpace(ConfirmNewPassword))
                    {
                        UserDialogs.Instance.Toast(new ToastConfig(AppResources.PleaseInputConfirmNewPassword).SetIcon("Close_32px.png").SetMessageTextColor(Color.Red));
                        return;
                    }
                    ConfirmNewPassword = ConfirmNewPassword.Trim();
                    // Check special character
                    if (FormBase.HasPasswordSpecicalChar(ConfirmNewPassword))
                    {
                        UserDialogs.Instance.Toast(new ToastConfig(AppResources.DoNotInputConfirmNewPasswordHasSpecialCharacter).SetIcon("Close_32px.png").SetMessageTextColor(Color.Red));
                        return;
                    }
                    //NewPasswordAndConfirmNewPasswordIsNotMatch
                    if (NewPassword != ConfirmNewPassword)
                    {
                        UserDialogs.Instance.Toast(new ToastConfig(AppResources.NewPasswordAndConfirmNewPasswordIsNotMatch).SetIcon("Close_32px.png").SetMessageTextColor(Color.Red));
                        return;
                    }
                    // Checking special character
                    bool response = false;
                    using (UserDialogs.Instance.Loading(AppResources.DoingChangeUserNameAndPassword))
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
                    UserDialogs.Instance.Toast(new ToastConfig(AppResources.UpdateUserNameAndPasswordIsDoneSignout).SetIcon("OK_32px.png").SetMessageTextColor(Color.WhiteSmoke));
                    await Task.Delay(UserConstant.WaitCanView);
                    DisplOK?.Invoke();
                }));
            }
        }
        public ChangeUserAndPassViewModel()
        {
        }
    }
}
