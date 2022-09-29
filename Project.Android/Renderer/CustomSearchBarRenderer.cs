using System;
using Android.Content;
using Android.Content.Res;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Project.Android.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(Xamarin.Forms.SearchBar), typeof(CustomSearchBarRenderer))]
namespace Project.Android.Renderer
{
    public class CustomSearchBarRenderer : SearchBarRenderer
    {
        public CustomSearchBarRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                var plateId = Resources.GetIdentifier("android:id/search_plate", null, null);
                var plate = Control.FindViewById(plateId);
                plate.SetBackgroundColor(Color.Transparent);

                AutoCompleteTextView textField = (AutoCompleteTextView)
                    (((Control.GetChildAt(0) as ViewGroup)
                        .GetChildAt(2) as ViewGroup)
                        .GetChildAt(1) as ViewGroup)
                        .GetChildAt(0);

                if (textField != null)
                    textField.ImeOptions = (ImeAction)ImeFlags.NoExtractUi; // This does the magic
            }
        }
    }
}
