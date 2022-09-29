using System;
using System.Collections.Generic;
using Common;
using Project.ViewModels.Main.Setting;
using Rg.Plugins.Popup.Services;
using S3WAN.ViewModels.Login;
using S3WAN.Views.Login;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Project.Views.Main.Setting
{
    public partial class SettingView : ContentView
    {
        [Obsolete]
        public SettingView()
        {
            InitializeComponent();

            this.BindingContextChanged += (o, e) =>
            {
                if (BindingContext == null)
                {
                    return;
                }
                if (BindingContext.GetType() != typeof(SettingViewModel))
                {
                    return;
                }

                SettingViewModel _vm = (BindingContext as SettingViewModel);

                _vm.DisplSignOut = new Action(async () =>
                {
                    if (PopupNavigation.Instance.PopupStack.Count > 0)
                    {
                        await PopupNavigation.Instance.PopAllAsync(true);
                    }


                    LoginViewModel _v = new LoginViewModel()
                    {
                        UserName = Settings.UserName,
                        Password = Settings.PassWord,
                        ResponseOK = true,
                        ResponseMessage = "",
                        IsBusy = false,
                        AutoLogin = false,
                        VersionStr = String.Format("{0}.{1}", VersionTracking.CurrentVersion, VersionTracking.CurrentBuild)
                    };
                    Xamarin.Forms.Application.Current.MainPage = new LoginView()
                    {
                        BindingContext = _v
                    };
                    return;
                });
            };

        }
    }
}
