using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Common;
using Project.Language;
using Project.ViewModels.Common;

namespace S3WAN.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase
    {
        private bool _isBusy = false;
        public bool IsBusy { get => _isBusy; set { _isBusy = value; OnPropertyChanged("IsBusy"); } }
        private string _respMessage = "";
        public string ResponseMessage { get => _respMessage; set { _respMessage = value; OnPropertyChanged("ResponseMessage"); } }
        private bool _respOK = true;
        public bool ResponseOK { get => _respOK; set { _respOK = value; OnPropertyChanged("ResponseOK"); } }

        private string _UserName = Settings.UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged("UserName"); } }
        private string _Password = Settings.PassWord;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged("Password"); } }

        private string _VersionStr;
        public string VersionStr { get => _VersionStr; set { _VersionStr = value; OnPropertyChanged("VersionStr"); } }

        private bool _Remember = Settings.Remember;
        public bool Remember
        {
            get => _Remember;
            set
            {
                _Remember = value;
                OnPropertyChanged("Remember");
                Settings.Remember = value;
            }
        }

        public ICommand RememberCmd
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    Remember = !Remember;
                }));
            }
        }
        public Action<string, string, string> DisplHelp;
        public ICommand HelpCmd
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    DisplHelp?.Invoke("google.com.vn", "vjnhbeo@gmail.com", "0987654321");
                }));
            }
        }

        #region Config info
        private bool _IsConfig = false;
        public bool IsConfig { get => _IsConfig; set { _IsConfig = value; OnPropertyChanged("IsConfig"); } }
        #endregion Config info


        public Action<UserModel, ObservableCollection<MenuItemModel>> DisplLoginOK;
        public Action DisplUserNameFocus;
        public Action DisplPasswordFocus;

        public ICommand LoginCmd
        {
            get
            {
                return new RelayCommand(new Action(async () =>
                {
                    // Checking
                    if (string.IsNullOrWhiteSpace(UserName))
                    {
                        DisplUserNameFocus?.Invoke();
                        return;
                    }
                    UserName = UserName.Trim();
                    if (string.IsNullOrWhiteSpace(Password))
                    {
                        DisplPasswordFocus?.Invoke();
                        return;
                    }
                    Password = Password.Trim();

                    ResponseOK = true;
                    ResponseMessage = AppResources.DoingLogin;
                    IsBusy = true;

                    if (Remember)
                    {
                        Settings.UserName = UserName;
                        Settings.PassWord = Password;
                    }
                    else
                    {
                        Settings.UserName = "";
                        Settings.PassWord = "";
                    }

                    UserModel _usr = new UserModel()
                    {
                        APIKey = "",
                        SessionKey = "",
                        DisplayName = "VinhBeo",
                        Id = 1,
                        IsActivate = true,
                        IsExpired = false,
                        IsLock = false,
                        Position = PositionCode.ADMIN,
                        ProjectName = "APP STARBUCKS ORDER",
                        ProjectDescription = "Make order app by VinhBeo",
                        Lat = UserConstant.Lat,
                        Long = UserConstant.Long,
                        UserName = UserName,
                        Password = Password
                    };

                    // Checking user info
                    if (_usr.IsExpired)
                    {
                        ResponseOK = false;
                        ResponseMessage = AppResources.UserIsExpiredPleaseContactAdmin;
                        return;
                    }
                    if (_usr.IsLock)
                    {
                        ResponseOK = false;
                        ResponseMessage = AppResources.UserIsLockedPleaseContactAdmin;
                        return;
                    }

                    #region Load menu
                    ObservableCollection<MenuItemModel> _menus = new ObservableCollection<MenuItemModel>()
                    {
                        new MenuItemModel()
                        {
                            Image = "chocolate_frappuccino.png",
                            Name = "Chocolate Frappuccino",
                            Price = "30",
                            IsFavorite = true,
                            Type = TypeEnum.Chocolate,
                            Size = SizeEnum.Small,
                            Description = "Rich mocha-flavored sauce meets up with chocolaty chips, milk and ice for a blender bash. Top it off with sweetened whipped cream and mocha drizzle for a real party in your mouth.",
                            Rating = 5,
                        },
                        new MenuItemModel()
                        {
                            Image = "tea_frappuccino.png",
                            Name = "Tea Frappuccino",
                            Price = "20",
                            IsFavorite = false,
                            Type = TypeEnum.Tea,
                            Size = SizeEnum.Small,
                            Description = "This blend of sweetened premium matcha green tea, milk and ice—topped off with sweetened whipped cream—inspires a delicious boost and good green vibes.",
                            Rating = 4.5,
                        },
                        new MenuItemModel()
                        {
                            Image = "coffee_frappuccino.png",
                            Name = "Coffee Frappuccino",
                            Price = "10",
                            IsFavorite = true,
                            Type = TypeEnum.Coffee,
                            Size = SizeEnum.Small,
                            Description = "Coffee meets milk and ice in a blender for a rumble-and-tumble togetherness to create one of our most-beloved original Frappuccino® blended beverages.",
                            Rating = 4.7,
                        }
                    };
                    #endregion
                    DisplLoginOK?.Invoke(_usr,_menus);
                    FormBase.IsLogin = true;
                }));
            }
        }

        private bool _AutoLogin;
        public bool AutoLogin { get => _AutoLogin; set { _AutoLogin = value; OnPropertyChanged("AutoLogin"); } }

        public LoginViewModel()
        {
            FormBase.IsLogin = false;
        }
    }

    public class ClientConfigClass
    {
        public string ClientCode { get; set; }
        public string Name { get; set; }
        public string CloudEndpoint { get; set; }
        public int CloudPort { get; set; }
        public string CloudHardKey { get; set; }
        public string LoginEndpoint { get; set; }
        public string LoginHardKey { get; set; }
        public string ApiEndpoint { get; set; }
        public string ApiHardKey { get; set; }
        public string PMSEndpoint { get; set; }
        public string PMSHardKey { get; set; }
    }

    public class ConfigFileClass
    {
        public string Data { get; set; }
        public string ReleaseBy { get; set; }
        public DateTime ReleaseTime { get; set; }
        public string MD5 { get; set; }
    }
}
