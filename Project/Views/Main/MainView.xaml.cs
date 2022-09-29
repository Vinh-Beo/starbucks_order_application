using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Project.Language;
using Project.ViewModels.Common;
using Project.ViewModels.Main.Detail;
using Project.ViewModels.Main.Home;
using Project.Views.Main.Detail;
using Rg.Plugins.Popup.Services;
using S3WAN.ViewModels.Main;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S3WAN.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : TabbedPage
    {
        public MainView()
        {
            InitializeComponent();

            this.BindingContextChanged += (o, e) =>
            {
                if (BindingContext == null)
                {
                    return;
                }
                if (BindingContext.GetType() != typeof(MainViewModel))
                {
                    return;
                }

                MainViewModel _vm = (BindingContext as MainViewModel);
                CurrentPage = tpHome;
            };
        }

        void TabbedPage_CurrentPageChanged(System.Object sender, System.EventArgs e)
        {
            if (sender == null)
            {
                return;
            }
            if (sender.GetType() != typeof(MainView))
            {
                return;
            }
            MainView _v = sender as MainView;
            if (_v.CurrentPage == null)
            {
                return;
            }
            if (_v.BindingContext == null)
            {
                return;
            }
            if (_v.BindingContext.GetType() != typeof(MainViewModel))
            {
                return;
            }
            MainViewModel _vm = _v.BindingContext as MainViewModel;

            if (_v.CurrentPage == tpHome)
            {
                #region Register action
                _vm.Home.DisplCart = new Action(() =>
                {
                    //if (_vm.Cart.LoadCartCommand != null && _vm.Cart.LoadCartCommand.CanExecute(null))
                    //{
                    //    _vm.Cart.LoadCartCommand.Execute(null);
                    //}
                    _v.CurrentPage = _v.tpCart;
                });
                #endregion
                foreach (TypeEnumModel _type in _vm.Home.Types)
                {
                    _type.DisplSel = new Action(() =>
                    {
                        _type.IsSelected = true;
                        // Unselect 
                        List<TypeEnumModel> _unSelectList = _vm.Home.Types.Where(p => p.Code != _type.Code).ToList();
                        foreach (TypeEnumModel _item in _unSelectList)
                        {
                            _item.IsSelected = false;
                        }

                        // Load items from type
                        _vm.Home.Menus.Clear();
                        if (_type.Code == TypeEnum.All)
                        {
                            _vm.Home.Menus = _vm.Home.CloneMenus;
                        }
                        else
                        {
                            _vm.Home.Menus = new ObservableCollection<MenuItemModel>(_vm.Home.CloneMenus.Where(p => p.Type == _type.Code));
                        }
                    });
                }
                foreach (MenuItemModel item in _vm.Home.Menus)
                {
                    item.DisplShowDetail = new Action<MenuItemModel>((_info) =>
                    {
                        _vm.Detail = new DetailViewModel()
                        {
                            Info = _info,
                            OrderNumber = 0,
                            Sizes = FormBase.Sizes,
                            SelectItem = new MenuItemModel(),
                            IsDetail = true,
                        };
                        _vm.Detail.DisplBack = new Action(() =>
                        {
                            _v.CurrentPage = tpHome;
                        });
                        _v.CurrentPage = tpDetail;
                    });
                }
            }
            else if (_v.CurrentPage == tpDetail)
            {
                _vm.Detail.DisplOrder = new Action<OrderItemModel>((_order) =>
                {
                    _vm.Cart.Items.Add(_order);
                });
            }
            else if (_v.CurrentPage == tpCart)
            {
                //if (_vm.Cart.LoadCartCommand != null &&
                //    _vm.Cart.LoadCartCommand.CanExecute(null))
                //{
                //    _vm.Cart.LoadCartCommand.Execute(null);
                //}
                _vm.Cart.DisplBack = new Action(() =>
                {
                    _v.CurrentPage = tpHome;
                });
                _vm.Cart.DisplDeleteAll = new Action(() =>
                {
                    _vm.Cart.Items.Clear();
                });
                _v.CurrentPage = tpCart;
            }
            else if (_v.CurrentPage == tpNos)
            {
                foreach (TypeEnumModel _type in _vm.Notifications.Types)
                {
                    _type.DisplSel = new Action(() =>
                    {
                        _type.IsSelected = true;
                        // Unselect 
                        List<TypeEnumModel> _unSelectList = _vm.Home.Types.Where(p => p.Code != _type.Code).ToList();
                        foreach (TypeEnumModel _item in _unSelectList)
                        {
                            _item.IsSelected = false;
                        }

                        // Load items from type
                        _vm.Notifications.Promos.Clear();
                        if (_type.Code == TypeEnum.All)
                        {
                            _vm.Notifications.Promos = _vm.Notifications.ClonePromos;
                        }
                        else
                        {
                            _vm.Notifications.Promos = new ObservableCollection<PromoItemModel>(_vm.Notifications.ClonePromos.Where(p => p.Type == _type.Code));
                        }
                    });
                }
            }
        }
    }
}
