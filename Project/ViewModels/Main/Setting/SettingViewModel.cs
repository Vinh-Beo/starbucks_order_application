using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Common;
using Project.Language;
using Project.ViewModels.Main.Setting.About;
using Project.Views.Main.Setting.About;
using Project.Views.Main.Setting.User;
using S3WAN.ViewModels.Main.Setting.User;
using S3WAN.Views.Common;
using Xamarin.Forms;

namespace Project.ViewModels.Main.Setting
{
    public class SettingViewModel : ViewModelBase
    {
        private bool _isBusy = false;
        public bool IsBusy { get => _isBusy; set { _isBusy = value; OnPropertyChanged("IsBusy"); } }
        private string _respMessage = "";
        public string ResponseMessage { get => _respMessage; set { _respMessage = value; OnPropertyChanged("ResponseMessage"); } }
        private bool _respOK = true;
        public bool ResponseOK { get => _respOK; set { _respOK = value; OnPropertyChanged("ResponseOK"); } }

        private UserModel _User;
        public UserModel User { get => _User; set { _User = value; OnPropertyChanged("User"); } }

        public Action DisplSignOut;
        public ICommand SignOutCmd
        {
            get
            {
                return new RelayCommand(new Action(async () =>
                {
                    IsBusy = true;
                    await Task.Delay(1000);

                    IsBusy = false;
                    DisplSignOut?.Invoke();

                    FormBase.IsLogin = false;
                }));
            }
        }

        public ICommand AboutCmd
        {
            get
            {
                return new RelayCommand(new Action(async () =>
                {
                    AboutView _p = new AboutView()
                    {
                        BindingContext = new AboutViewModel()
                        {
                            IsBusy = false,
                            ResponseOK = true,
                            ResponseMessage = "",
                            WebStr = "google.com.vn",
                            EmailStr = "vjnhbeo@gmail.com",
                            HotLineStr ="0987654321",
                            DisplClose = new Action(() =>
                            {
                                Application.Current.MainPage.Navigation.PopModalAsync();
                            })
                        }
                    };
                    await Application.Current.MainPage.Navigation.PushModalAsync(_p);
                }));
            }
        }
        public ICommand ChangeUserPassCmd
        {
            get
            {
                return new RelayCommand(new Action(async () =>
                {
                    // Display new popup
                    ChangeUserAndPassView _p = new ChangeUserAndPassView()
                    {
                        BindingContext = new ChangeUserAndPassViewModel()
                        {
                            User = User,
                            UserName = User.UserName,
                            OldPassword = "",
                            NewPassword = "",
                            ConfirmNewPassword = "",
                            DisplClose = new Action(() =>
                            {
                                Application.Current.MainPage.Navigation.PopModalAsync();
                            }),
                            DisplOK = new Action(() =>
                            {
                                DisplSignOut?.Invoke();
                            })
                        }
                    };
                    await Application.Current.MainPage.Navigation.PushModalAsync(_p);
                }));
            }
        }
        public ICommand ChangeUserInfoCmd
        {
            get
            {
                return new RelayCommand(new Action(async () =>
                {
                    ChangeUserInfoView _p = new ChangeUserInfoView()
                    {
                        BindingContext = new ChangeUserInfoViewModel()
                        {
                            User = User,
                            DisplayName = "Nguyen Tran Vinh",
                            Phone = "0987654321",
                            Email = "vjnhbeo@gmail.com",
                            DisplClose = new Action(() =>
                            {
                                Application.Current.MainPage.Navigation.PopModalAsync();
                            })
                        }
                    };
                    await Application.Current.MainPage.Navigation.PushModalAsync(_p);
                }));
            }
        }
        public SettingViewModel()
        {
        }
    }
}
