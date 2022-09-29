using System;
using System.Threading.Tasks;
using Common;
using S3WAN.ViewModels.Login;
using S3WAN.Views.Login;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace S3WAN
{
    public partial class App : Application
    {
        [Obsolete]
        public App()
        {
            InitializeComponent();

            Project.Language.AppResources.Culture = Plugin.Multilingual.CrossMultilingual.Current.DeviceCultureInfo;
            VersionTracking.Track();
            MainPage = new LoginView()
            {
                BindingContext = new LoginViewModel()
                {
                    UserName = Settings.UserName,
                    Password = Settings.PassWord,
                    ResponseOK = true,
                    ResponseMessage = "",
                    IsBusy = false,
                    AutoLogin = true,
                    VersionStr = String.Format("{0}.{1}", VersionTracking.CurrentVersion, VersionTracking.CurrentBuild),
                }
            };
        }

        protected override void OnStart()
        {
        }

        protected override async void OnSleep()
        {
            await Task.Delay(100);
        }

        protected override void OnResume()
        {
        }
    }
}
