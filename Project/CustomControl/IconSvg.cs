using System;
using System.IO;
using Common;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace CustomControl
{
    public class IconSvg : Frame
    {
        private readonly SKCanvasView _canvasView = new SKCanvasView();
        public IconSvg()
        {
            Padding = new Thickness(0);

            // Thanks to TheMax for pointing out that on mobile, the icon will have a shadow by default.
            // Also it has a white background, which we might not want.
            HasShadow = false;
            BackgroundColor = Color.White;
            CornerRadius = 5;
            Content = _canvasView;
            _canvasView.PaintSurface += CanvasViewOnPaintSurface;
        }

        public static readonly BindableProperty IconFilePathProperty = BindableProperty.Create(
        nameof(ResourceId),
        typeof(string),
        typeof(IconSvg),
        default(string),
        propertyChanged: RedrawCanvas);

        public string ResourceId
        {
            get => (string)GetValue(IconFilePathProperty);
            set => SetValue(IconFilePathProperty, value);
        }
        public static readonly BindableProperty TintColorProperty = BindableProperty.Create(
        nameof(TintColor),
        typeof(Color),
        typeof(IconSvg),
        default(Color),
        propertyChanged: RedrawCanvas);

        public Color TintColor
        {
            get => (Color)GetValue(TintColorProperty);
            set => SetValue(TintColorProperty, value);
        }

        private static void RedrawCanvas(BindableObject bindable, object oldvalue, object newvalue)
        {
            IconSvg svgIcon = bindable as IconSvg;
            svgIcon?._canvasView.InvalidateSurface();
        }

        private void CanvasViewOnPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKCanvas canvas = args.Surface.Canvas;
            canvas.Clear();

            if (string.IsNullOrEmpty(ResourceId))
                return;
            string _resource = GetType().Assembly.GetName().Name + "." + UserConstant.ResourcePath + "." + ResourceId;
            using (Stream stream = GetType().Assembly.GetManifestResourceStream(_resource))
            {
                SKSvg svg = new SKSvg();
                svg.Load(stream);

                SKImageInfo info = args.Info;
                canvas.Translate(info.Width / 2f, info.Height / 2f);

                SKRect bounds = svg.ViewBox;
                float xRatio = info.Width / bounds.Width;
                float yRatio = info.Height / bounds.Height;

                float ratio = Math.Min(xRatio, yRatio);

                canvas.Scale(ratio);
                canvas.Translate(-bounds.MidX, -bounds.MidY);
                using (var paint = new SKPaint())
                {
                    paint.ColorFilter = SKColorFilter.CreateBlendMode(SKColor.Parse(TintColor.ToHex()), SKBlendMode.SrcIn);
                    canvas.DrawPicture(svg.Picture, paint);
                }
            }
        }
    }

}
