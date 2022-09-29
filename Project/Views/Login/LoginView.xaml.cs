using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Converter;
using Project.Language;
using Project.ViewModels.Common;
using Project.Views.Main;
using Rg.Plugins.Popup.Services;
using S3WAN.ViewModels.Login;
using S3WAN.ViewModels.Login.Help;
using S3WAN.ViewModels.Main;
using S3WAN.Views.Login.Help;
using S3WAN.Views.Main;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace S3WAN.Views.Login
{
    public partial class LoginView : ContentPage
    {
        [Obsolete]
        public LoginView()
        {
            InitializeComponent();
            FormBase.DeviceInfo.Density = DeviceDisplay.MainDisplayInfo.Density;
            this.SizeChanged += (object sender, EventArgs e) =>
            {
                FormBase.DeviceInfo.Width = this.Width;
                FormBase.DeviceInfo.Height = this.Height;

                Console.WriteLine("Screen size [{0},{1}]", FormBase.DeviceInfo.Width, FormBase.DeviceInfo.Height);
            };
            this.BindingContextChanged += async (o, e) =>
            {
                if (BindingContext == null)
                {
                    return;
                }
                if (BindingContext.GetType() != typeof(ViewModels.Login.LoginViewModel))
                {
                    return;
                }

                ViewModels.Login.LoginViewModel _vm = (BindingContext as ViewModels.Login.LoginViewModel);

                _vm.DisplUserNameFocus += () =>
                {
                    txbUserName.Focus();
                };
                _vm.DisplPasswordFocus += () =>
                {
                    txbPassword.Focus();
                };
                _vm.DisplHelp = new Action<string, string, string>(async (_web, _email, _hotline) =>
                {
                    HelpView _p = new HelpView()
                    {
                        BindingContext = new ViewModels.Login.Help.HelpViewModel()
                        {
                            Website = _web,
                            Email = _email,
                            Hotline = _hotline,
                            DisplClose = new Action(async () =>
                            {
                                await Navigation.PopModalAsync(true);
                            })
                        }
                    };

                    await Navigation.PushModalAsync(_p, true);
                });
                _vm.DisplLoginOK +=new Action<UserModel,ObservableCollection<MenuItemModel>>(async (_usr,_menus) =>
                {
                    if (PopupNavigation.Instance.PopupStack.Count > 0)
                    {
                        await PopupNavigation.Instance.PopAllAsync(true);
                    }

                    MainViewModel _mv = new MainViewModel()
                    {
                        IsBusy = false,
                        ResponseOK = true,
                        ResponseMessage = "",
                        User = _usr,
                        Home = new Project.ViewModels.Main.Home.HomeViewModel()
                        {
                            IsBusy = false,
                            ResponseOK = true,
                            ResponseMessage = "",
                            User = _usr,
                            Menus = _menus,
                            CloneMenus = new ObservableCollection<MenuItemModel>(_menus),
                            Types = FormBase.Types,
                            IsSearch = false,
                        },
                        Setting = new Project.ViewModels.Main.Setting.SettingViewModel()
                        {
                            IsBusy = false,
                            ResponseOK = true,
                            ResponseMessage = "",
                            User = _usr,
                        },
                        Detail = new Project.ViewModels.Main.Detail.DetailViewModel()
                        {
                            Info = new MenuItemModel(),
                            OrderNumber = 0,
                            Sizes = new ObservableCollection<DetailSize>(),
                            SelectItem = new MenuItemModel(),
                            IsDetail = false,
                        },
                        Cart = new Project.ViewModels.Main.Cart.CartViewModel()
                        {
                            Items = new ObservableCollection<OrderItemModel>(),
                            TotalPrice = "0",
                        },
                        Notifications = new Project.ViewModels.Main.Notification.NotificationViewModel()
                        {
                            User = _usr,
                            Promos = new ObservableCollection<PromoItemModel>(),
                            ClonePromos = new ObservableCollection<PromoItemModel>(),
                            Types = FormBase.Types,
                        },
                        SelectedViewModelIndex = 2
                    };

                    // Load notifies
                    if (_mv.Notifications.LoadPromosCommand != null && _mv.Notifications.LoadPromosCommand.CanExecute(null))
                    {
                        _mv.Notifications.LoadPromosCommand.Execute(null);
                    }

                    // Update notify count
                    _mv.NotifyCount = _mv.Notifications.Promos.Where(p => p.IsNew).ToList().Count;

                    try
                    {
                        await Task.Factory.StartNew(async () =>
                        {
                            try
                            {
                                await Task.Delay(5000);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                                return;
                            }
                        });
                    }
                    catch (OperationCanceledException ex)
                    {
                        Console.WriteLine($"{nameof(OperationCanceledException)} thrown with message: {ex.Message}");
                        _vm.IsBusy = false;
                        _vm.ResponseMessage = "";
                        _vm.ResponseOK = false;
                        return;
                    }

                    _vm.IsBusy = false;
                    _vm.ResponseMessage = "";
                    _vm.ResponseOK = false;

                    FormBase.MainViewModel = _mv;
                    Application.Current.MainPage = new MainView()
                    {
                        BindingContext = _mv
                    };
                });
                // Do auto login if OK
                if (_vm.AutoLogin)
                {
                    if (!string.IsNullOrWhiteSpace(_vm.UserName) &&
                            !string.IsNullOrWhiteSpace(_vm.Password))
                    {
                        // Auto login
                        if (_vm.LoginCmd != null)
                        {
                            if (_vm.LoginCmd.CanExecute(null))
                            {
                                _vm.LoginCmd.Execute(null);
                            }
                        }
                    }
                }
            };
        }
    }
}
