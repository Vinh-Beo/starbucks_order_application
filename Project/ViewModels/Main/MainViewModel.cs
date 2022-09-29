using System.Threading;
using Common;
using Project.ViewModels.Main.Cart;
using Project.ViewModels.Main.Detail;
using Project.ViewModels.Main.Home;
using Project.ViewModels.Main.Notification;
using Project.ViewModels.Main.Setting;

namespace S3WAN.ViewModels.Main
{
    public class MainViewModel : ViewModelBase
    {
        private int _SelectedViewModelIndex;
        public int SelectedViewModelIndex { get => _SelectedViewModelIndex; set { _SelectedViewModelIndex = value; OnPropertyChanged("SelectedViewModelIndex"); } }

        private bool _isBusy = false;
        public bool IsBusy { get => _isBusy; set { _isBusy = value; OnPropertyChanged("IsBusy"); } }
        private string _respMessage = "";
        public string ResponseMessage { get => _respMessage; set { _respMessage = value; OnPropertyChanged("ResponseMessage"); } }
        private bool _respOK = true;
        public bool ResponseOK { get => _respOK; set { _respOK = value; OnPropertyChanged("ResponseOK"); } }

        private UserModel _Usr;
        public UserModel User { get => _Usr; set { _Usr = value; OnPropertyChanged("User"); } }

        #region Home
        private HomeViewModel _Home;
        public HomeViewModel Home { get => _Home; set { _Home = value; OnPropertyChanged("Home"); } }
        #endregion


        private CartViewModel _Cart;
        public CartViewModel Cart { get => _Cart; set { _Cart = value; OnPropertyChanged("Cart"); } }

        private DetailViewModel _Detail;
        public DetailViewModel Detail { get => _Detail; set { _Detail = value; OnPropertyChanged("Detail"); } }

        private NotificationViewModel _Notifications;
        public NotificationViewModel Notifications { get => _Notifications; set { _Notifications = value; OnPropertyChanged("Notifications"); } }

        private int NostifyCount;
        public int NotifyCount { get => NostifyCount; set { NostifyCount = value; OnPropertyChanged("NotifyCount"); } }

        #region Setting
        private SettingViewModel _Setting;
        public SettingViewModel Setting { get => _Setting; set { _Setting = value; OnPropertyChanged("Setting"); } }

        #endregion
        public MainViewModel()
        {
        }
    }
}
