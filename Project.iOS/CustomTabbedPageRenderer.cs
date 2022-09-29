using System;
using Project.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(CustomTabbedPageRenderer))]
namespace Project.iOS
{
    public class CustomTabbedPageRenderer : TabbedRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                return;
            }

            //TabBar.TintColor = UIKit.UIColor.Black;
            //TabBar.BarTintColor = UIKit.UIColor.FromRGB(255, 128, 0);
            //TabBar.BackgroundColor = UIKit.UIColor.FromRGBA(35, 176, 189, 230);
            TabBar.BackgroundColor = (e.NewElement as TabbedPage).BarBackgroundColor.ToUIColor();
        }
    }
}

