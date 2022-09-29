using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using CustomControl;
using Project.Android.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomImageEntry), typeof(ImageEntryRenderer))]
namespace Project.Android.Renderers
{
    public class ImageEntryRenderer : EntryRenderer
    {
        CustomImageEntry element;
        public ImageEntryRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            element = (CustomImageEntry)this.Element;


            var editText = this.Control;
            if (!string.IsNullOrEmpty(element.Image))
            {
                switch (element.ImageAlignment)
                {
                    case ImageAlignment.Left:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(element.Image), null, null, null);
                        break;
                    case ImageAlignment.Right:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(null, null, GetDrawable(element.Image), null);
                        break;
                }
            }
            editText.CompoundDrawablePadding = 25;
            Control.Background.SetColorFilter(element.LineColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
        }

        private BitmapDrawable GetDrawable(string imageEntryImage)
        {
            string[] remove = { ".png", ".jpg", ".jpeg" };
            string inputText = imageEntryImage;

            foreach (string item in remove)
                if (inputText.EndsWith(item))
                {
                    inputText = inputText.Substring(0, inputText.LastIndexOf(item));
                    break; //only allow one match at most
                }

            int resID = Resources.GetIdentifier(inputText.ToLower(), nameof(Resource.Drawable).ToLower(), this.Context.PackageName);//imageEntryImage.ToLower()
            //int resID = 2131165673;
            var drawable = ContextCompat.GetDrawable(this.Context, resID);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;

            return new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, element.ImageWidth * 2, element.ImageHeight * 2, true));
        }

    }
}