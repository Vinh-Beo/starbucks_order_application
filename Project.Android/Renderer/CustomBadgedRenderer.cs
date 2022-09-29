using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Widget;
using Plugin.Badge.Droid;
using Project.Android.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(CustomBadgedRenderer))]
namespace Project.Android.Renderer
{
    public class CustomBadgedRenderer : BadgedTabbedPageRenderer
    {

        public CustomBadgedRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.TabbedPage> e)
        {
            base.OnElementChanged(e);
        }
    }
}
