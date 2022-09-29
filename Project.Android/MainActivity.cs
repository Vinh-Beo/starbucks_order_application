using System;

using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using S3WAN;
using Android;
using Android.Util;
using Acr.UserDialogs;

namespace Project.Android
{
    [Activity(Label = "Project",
        Icon = "@mipmap/icon",
        Theme = "@style/MainTheme",
        MainLauncher = true,
        HardwareAccelerated = true,
        ConfigurationChanges = ConfigChanges.FontScale | ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            this.Window.RequestFeature(WindowFeatures.NoTitle);

            this.Window.AddFlags(WindowManagerFlags.Fullscreen |
                                WindowManagerFlags.TurnScreenOn |
                                WindowManagerFlags.LayoutNoLimits |
                                WindowManagerFlags.LayoutInScreen);
            this.Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);

            this.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(SystemUiFlags.LowProfile
                          | SystemUiFlags.Fullscreen
                          | SystemUiFlags.LayoutStable
                          | SystemUiFlags.HideNavigation
                          | SystemUiFlags.Immersive
                          | SystemUiFlags.ImmersiveSticky);

            base.OnCreate(savedInstanceState);
            try
            {
                this.Window.Attributes.LayoutInDisplayCutoutMode = LayoutInDisplayCutoutMode.ShortEdges;
            }
            catch (Exception)
            {

            }
            initFontScale();
            Rg.Plugins.Popup.Popup.Init(this);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            UserDialogs.Init(this);

            LoadApplication(new App());
            this.Window.SetSoftInputMode(SoftInput.AdjustResize | SoftInput.StateHidden);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {

            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnUserInteraction()
        {
            this.Window.AddFlags(WindowManagerFlags.Fullscreen |
                                WindowManagerFlags.TurnScreenOn |
                                WindowManagerFlags.LayoutNoLimits |
                                WindowManagerFlags.LayoutInScreen);
            this.Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);
            this.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(SystemUiFlags.LowProfile
                                                          | SystemUiFlags.Fullscreen
                                                          | SystemUiFlags.LayoutStable
                                                          | SystemUiFlags.HideNavigation
                                                          | SystemUiFlags.Immersive
                                                          | SystemUiFlags.ImmersiveSticky);
            base.OnUserInteraction();
        }

        protected override void OnResume()
        {
            this.Window.AddFlags(WindowManagerFlags.Fullscreen |
                                 WindowManagerFlags.TurnScreenOn |
                                 WindowManagerFlags.LayoutNoLimits |
                                 WindowManagerFlags.LayoutInScreen);
            this.Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);

            this.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(SystemUiFlags.LowProfile
                                                                            | SystemUiFlags.Fullscreen
                                                                            | SystemUiFlags.LayoutStable
                                                                            | SystemUiFlags.HideNavigation
                                                                            | SystemUiFlags.Immersive
                                                                            | SystemUiFlags.ImmersiveSticky);
            base.OnResume();
        }

        private void initFontScale()
        {
            Configuration configuration = Resources.Configuration;
            configuration.FontScale = (float)1.1;
            //0.85 small, 1 standard, 1.15 big，1.3 more bigger ，1.45 supper big 
            DisplayMetrics metrics = new DisplayMetrics();
            WindowManager.DefaultDisplay.GetMetrics(metrics);
            metrics.ScaledDensity = configuration.FontScale * metrics.Density;
            BaseContext.Resources.UpdateConfiguration(configuration, metrics);
        }
    }
}