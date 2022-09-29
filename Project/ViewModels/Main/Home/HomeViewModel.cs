using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Common;
using Project.ViewModels.Common;

namespace Project.ViewModels.Main.Home
{
    public class HomeViewModel : ViewModelBase
    {
        private bool _isBusy = false;
        public bool IsBusy { get => _isBusy; set { _isBusy = value; OnPropertyChanged("IsBusy"); } }
        private string _respMessage = "";
        public string ResponseMessage { get => _respMessage; set { _respMessage = value; OnPropertyChanged("ResponseMessage"); } }
        private bool _respOK = true;
        public bool ResponseOK { get => _respOK; set { _respOK = value; OnPropertyChanged("ResponseOK"); } }

        private bool _IsSearch;
        public bool IsSearch { get => _IsSearch; set { _IsSearch = value; OnPropertyChanged("IsSearch"); } }

        private UserModel _User;
        public UserModel User { get => _User; set { _User = value; OnPropertyChanged("User"); } }

        private ObservableCollection<MenuItemModel> _Menus = new ObservableCollection<MenuItemModel>();
        public ObservableCollection<MenuItemModel> Menus { get => _Menus; set { _Menus = value; OnPropertyChanged("Menus"); } }

        private ObservableCollection<MenuItemModel> _CloneMenus = new ObservableCollection<MenuItemModel>();
        public ObservableCollection<MenuItemModel> CloneMenus { get => _CloneMenus; set { _CloneMenus = value; OnPropertyChanged("CloneMenus"); } }

        private ObservableCollection<TypeEnumModel> _Types = new ObservableCollection<TypeEnumModel>();
        public ObservableCollection<TypeEnumModel> Types { get => _Types; set { _Types = value; OnPropertyChanged("Types"); } }


        #region Command
        public Action DisplDetail;
        public ICommand SearchCommand
        {
            get
            {
                return new RelayParamCommand(new Action<object>((object obj) =>
                {
                    if (obj == null)
                    {
                        return;
                    }

                    if (obj.GetType() != typeof(string))
                    {
                        return;
                    }
                    string _searchStr = obj as string;
                    if (_searchStr == null || _searchStr == "")
                    {
                        Menus = CloneMenus;
                        return;
                    }
                    InputChecker _check = new InputChecker();
                    _searchStr = _check.ConvertToUnSign(_searchStr.ToLower());
                    ObservableCollection<MenuItemModel> _tmp = new ObservableCollection<MenuItemModel>();
                    foreach (MenuItemModel item in Menus)
                    {
                        string _name = _check.ConvertToUnSign(item.Name.ToLower());
                        string _price = _check.ConvertToUnSign(item.Price.ToLower());
                        string _typeString = "";
                        if (item.Type == TypeEnum.Chocolate)
                        {
                            _typeString = "Chocolate";
                        }
                        else if (item.Type == TypeEnum.Coffee)
                        {
                            _typeString = "Coffee";
                        }
                        else if (item.Type == TypeEnum.Tea)
                        {
                            _typeString = "Tea";
                        }
                        string _type = _check.ConvertToUnSign(_typeString.ToLower());
                        if (_name.Contains(_searchStr) || _price.Contains(_searchStr) || _type.Contains(_searchStr))
                        {
                            _tmp.Add(item);
                        }
                    }
                    Menus = _tmp;
                }));
            }
        }
        public Action DisplCart;
        public ICommand CartCommand
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    DisplCart?.Invoke();
                }));
            }
        }
        #endregion
        public HomeViewModel()
        {
        }
    }
}
