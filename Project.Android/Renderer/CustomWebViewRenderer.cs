using Android.Content;
using Android.OS;
using Android.Views;
using Android.Webkit;
using JavaScriptWebView.Android.Renderers;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.WebView), typeof(CustomWebViewRenderer))]
namespace JavaScriptWebView.Android.Renderers
{
    public class CustomWebViewRenderer : WebViewRenderer
    {
        Context context;

        public CustomWebViewRenderer(Context context) : base(context)
        {
            this.context = context;
        }

        public override bool DispatchTouchEvent(MotionEvent e)
        {
            Parent.RequestDisallowInterceptTouchEvent(true);
            return base.DispatchTouchEvent(e);
        }
    }
}