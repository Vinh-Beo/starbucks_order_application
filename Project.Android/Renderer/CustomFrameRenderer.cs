using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Project.Android.Renderer;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(Xamarin.Forms.Frame), typeof(CustomFrameRenderer))]
namespace Project.Android.Renderer
{
    public class CustomFrameRenderer : FrameRenderer
    {

        public CustomFrameRenderer(Context context) : base(context)
        {
        }

        public override void Draw(Canvas canvas)
        {
            try
            {
                //base.Draw(canvas);
                if (Element == null)
                {
                    return;
                }

                using (var paint = new Paint
                {
                    AntiAlias = true
                })
                using (var path = new Path())
                using (Path.Direction direction = Path.Direction.Cw)
                using (Paint.Style style = Paint.Style.Stroke)
                using (var rect = new RectF(0, 0, canvas.Width, canvas.Height))
                {
                    var raduis = Application.Context.ToPixels(Element.CornerRadius);
                    path.AddRoundRect(rect, raduis, raduis, direction);
                    paint.StrokeWidth = Context.Resources.DisplayMetrics.Density;
                    paint.AntiAlias = true;
                    paint.SetStyle(style);
                    paint.Color = Element.BorderColor.ToAndroid();

                    canvas.Save();
                    canvas.ClipPath(path);
                    base.Draw(canvas);
                    canvas.DrawPath(path, paint);
                }
            }
            catch (Exception)
            {

            }

        }

    }
}
