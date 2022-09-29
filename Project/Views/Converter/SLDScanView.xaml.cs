using System;
using System.Collections.Generic;
using S3WAN.ViewModels.Main.Home.SLD;
using Xamarin.Forms;

namespace S3WAN.Views.Main.Home.SLD
{
    public partial class SLDScanView : ContentPage
    {
        public SLDScanView()
        {
            InitializeComponent();
            this.BindingContextChanged += (o, e) =>
            {
                if (BindingContext == null)
                {
                    return;
                }
                if (BindingContext.GetType() != typeof(SLDcanViewModel))
                {
                    return;
                }

                SLDcanViewModel _vm = (BindingContext as SLDcanViewModel);

                _vm.DisplClose += async () =>
                {
                    await Navigation.PopModalAsync(true);
                };
            };
        }
    }
}
