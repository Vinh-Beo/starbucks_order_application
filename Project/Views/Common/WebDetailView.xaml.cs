using System;
using System.Collections.Generic;
using Common;
using Xamarin.Forms;

namespace S3WAN.Views.Common
{
    public partial class WebDetailView : ContentPage
    {
        public WebDetailView()
        {
            InitializeComponent();
        }

        void Handle_Navigated(object sender, Xamarin.Forms.WebNavigatedEventArgs e)
        {
            if (BindingContext == null)
            {
                return;
            }
            if (BindingContext.GetType() != typeof(WebDetailViewModel))
            {
                return;
            }

            WebDetailViewModel _vm = (BindingContext as WebDetailViewModel);
            _vm.IsBusy = false;
        }
    }
}
