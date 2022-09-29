using System;
using System.Collections.Generic;
using Common;
using Project.ViewModels.Main.Detail;
using Project.ViewModels.Main.Home;
using Xamarin.CommunityToolkit.Converters;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Xamarin.Forms;

namespace Project.Views.Main.Detail
{
    public partial class DetailView : ContentView
    {
        public DetailView()
        {
            InitializeComponent();
        }

        private void Add_Tapped(object sender, EventArgs e)
        {
            if (BindingContext == null)
            {
                return;
            }
            if (BindingContext.GetType() != typeof(DetailViewModel))
            {
                return;
            }

            DetailViewModel _vm = (BindingContext as DetailViewModel);
            _vm.OrderNumber+= 1;
        }

        private void Substract_Tapped(object sender, EventArgs e)
        {

            if (BindingContext == null)
            {
                return;
            }
            if (BindingContext.GetType() != typeof(DetailViewModel))
            {
                return;
            }

            DetailViewModel _vm = (BindingContext as DetailViewModel);
            _vm.OrderNumber -= 1;
            if (_vm.OrderNumber <= 0)
            {
                _vm.OrderNumber = 0;
                return;
            }
        }
    }
}
