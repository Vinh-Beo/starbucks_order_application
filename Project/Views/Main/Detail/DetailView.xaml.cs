using System;
using Project.ViewModels.Common;
using Project.ViewModels.Main.Detail;
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

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (BindingContext == null && e == null)
            {
                return;
            }
            if (BindingContext.GetType() != typeof(DetailViewModel))
            {
                return;
            }
            DetailViewModel _vm = (BindingContext as DetailViewModel);
            TappedEventArgs _event = e as TappedEventArgs;

            if (_event.Parameter.GetType() != typeof(DetailSizeModel))
            {
                return;
            }

            DetailSizeModel _detailSize = _event.Parameter as DetailSizeModel;

            _vm.SizeItem = _detailSize;
            foreach (DetailSizeModel item in _vm.Sizes)
            {
                if (item == _detailSize)
                {
                    item.IsSelected = true;
                }
                else
                {
                    item.IsSelected = false;
                }
            }
        }
    }
}
