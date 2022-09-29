namespace Common
{
    public class UserModel : ViewModelBase
    {
        public bool IsBusy { get => isBusy; set { isBusy = value; OnPropertyChanged("IsBusy"); } }

        private bool isBusy = false;
        public bool ResponseOK { get => responseOK; set { responseOK = value; OnPropertyChanged("ResponseOK"); } }
        public string ResponseMessage { get => responseMessage; set { responseMessage = value; OnPropertyChanged("ResponseMessage"); } }

        private bool responseOK = false;
        private string responseMessage = "";

        private long _Id;
        public long Id { get => _Id; set { _Id = value; OnPropertyChanged("Id"); } }

        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged("UserName"); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged("Password"); } }
        private string _APIkey;
        public string APIKey { get => _APIkey; set { _APIkey = value; OnPropertyChanged("APIKey"); } }
        private string _SessionKey;
        public string SessionKey { get => _SessionKey; set { _SessionKey = value; OnPropertyChanged("SessionKey"); } }
        private bool _IsActivate = false;
        public bool IsActivate { get => _IsActivate; set { _IsActivate = value; OnPropertyChanged("IsActivate"); } }
        private bool _IsLock = true;
        public bool IsLock { get => _IsLock; set { _IsLock = value; OnPropertyChanged("IsLock"); } }
        private bool _IsExpired = true;
        public bool IsExpired { get => _IsExpired; set { _IsExpired = value; OnPropertyChanged("IsExpired"); } }

        private double _Lat;
        public double Lat { get => _Lat; set { _Lat = value; OnPropertyChanged("Lat"); } }
        private double _Long;
        public double Long { get => _Long; set { _Long = value; OnPropertyChanged("Long"); } }

        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged("DisplayName"); } }
        private string _Position;
        public string Position { get => _Position; set { _Position = value; OnPropertyChanged("Position"); } }

        private string _email;
        public string Email { get => _email; set { _email = value; OnPropertyChanged("Email"); } }

        private string _phoneNumber;
        public string PhoneNumber { get => _phoneNumber; set { _phoneNumber = value; OnPropertyChanged("PhoneNumber"); } }

        private string _ProjectName;
        public string ProjectName { get => _ProjectName; set { _ProjectName = value; OnPropertyChanged("ProjectName"); } }
        private string _ProjectDescription;
        public string ProjectDescription { get => _ProjectDescription; set { _ProjectDescription = value; OnPropertyChanged("ProjectDescription"); } }
    }
}
