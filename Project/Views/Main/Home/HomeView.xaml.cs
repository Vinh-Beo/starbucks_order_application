using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Common;
using Project.ViewModels.Common;
using Project.ViewModels.Main.Home;
using Xamarin.CommunityToolkit.Converters;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Xamarin.Forms;

namespace Project.Views.Main.Home
{
    public partial class HomeView : ContentView
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void Handle_Focused(object sender, FocusEventArgs e)
        {
            if (BindingContext == null)
            {
                return;
            }
            if (BindingContext.GetType() != typeof(HomeViewModel))
            {
                return;
            }

            HomeViewModel _vm = (BindingContext as HomeViewModel);

            _vm.IsSearch = true;
        }

        private void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (BindingContext == null)
            {
                return;
            }
            if (BindingContext.GetType() != typeof(HomeViewModel))
            {
                return;
            }

            HomeViewModel _vm = (BindingContext as HomeViewModel);
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                TypeEnumModel _type = _vm.Types.FirstOrDefault(p => p.IsSelected == true);
                if (_type.Code == TypeEnum.All)
                {
                    _vm.Menus = _vm.CloneMenus;
                }
                else
                {
                    _vm.Menus = new ObservableCollection<MenuItemModel>(_vm.CloneMenus.Where(p => p.Type == _type.Code));
                }
            }
            else
            {
                if (_vm.SearchCommand != null && _vm.SearchCommand.CanExecute(e.NewTextValue))
                {
                    _vm.SearchCommand.Execute(e.NewTextValue);
                }
            }
        }
    }
}
