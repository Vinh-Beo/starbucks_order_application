using System;
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using System.ComponentModel;
using Xamarin.Forms;
using Android.Graphics;
using Android.Graphics.Drawables;
using Project.Android.Renderers;
using CustomControl;

[assembly: ExportRendererAttribute(typeof(ImageColor), typeof(IconViewRenderer))]

namespace Project.Android.Renderers
{
    public class IconViewRenderer : ViewRenderer<ImageColor, ImageView>
    {
        private bool _isDisposed;

        public IconViewRenderer()
        {
            base.AutoPackage = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }
            _isDisposed = true;
            base.Dispose(disposing);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ImageColor> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                SetNativeControl(new ImageView(Context));
            }
            UpdateBitmap(e.OldElement);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == ImageColor.SourceProperty.PropertyName)
            {
                UpdateBitmap(null);
            }
            else if (e.PropertyName == ImageColor.ForegroundProperty.PropertyName)
            {
                UpdateBitmap(null);
            }
        }

        private void UpdateBitmap(ImageColor previous = null)
        {
            if (!_isDisposed && !string.IsNullOrWhiteSpace(Element.Source))
            {
                var d = Resources.GetDrawable(Element.Source).Mutate();
                d.SetColorFilter(new LightingColorFilter(Element.Foreground.ToAndroid(), Element.Foreground.ToAndroid()));
                d.Alpha = Element.Foreground.ToAndroid().A;
                Control.SetImageDrawable(d);
                ((IVisualElementController)Element).NativeSizeChanged();
            }
        }
    }
}
