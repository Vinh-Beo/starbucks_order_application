using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Widget;
using Project.Android.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(CustomButtonRenderer))]
namespace Project.Android.Renderer
{
    public class CustomButtonRenderer : ButtonRenderer
    {

        public CustomButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (Control == null || Element == null || e.OldElement != null) return;

            //var element = (CustomEntryRenderer)Element;
            //var ourCustomColorHere = element.BorderColor.ToAndroid();


            // Using this for remove underline
            if (Control != null)
            {
                Control.SetAllCaps(false);
                Control.SetTypeface(Typeface.Default, TypefaceStyle.Normal);
                Control.SetPadding(20, 5, 20, 5);
            }
        }
    }
}
