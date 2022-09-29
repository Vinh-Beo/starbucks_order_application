using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Views.InputMethods;
using Android.Widget;
using Project.Android.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Entry), typeof(CustomEntryRenderer))]
namespace Project.Android.Renderer
{
    public class CustomEntryRenderer : EntryRenderer
    {

        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        [Obsolete]
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control == null || Element == null || e.OldElement != null) return;

            // Using this for remove underline
            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(ColorStateList.ValueOf(global::Android.Graphics.Color.Argb(67,0,0,0)));
                gd.SetCornerRadius(22);
                Control.SetBackgroundDrawable(gd);
                Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
                Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.LightGray));
                Control.Gravity = global::Android.Views.GravityFlags.Center;
                Control.ImeOptions = (ImeAction)ImeFlags.NoExtractUi;
            }
        }
    }
}
