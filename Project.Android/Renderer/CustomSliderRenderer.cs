using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using Common;
using Project.Android;
using Project.Android.Renderer;
using CustomControl;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomControl.CustomSlider), typeof(CustomSliderRenderer))]
namespace Project.Android
{
    public class CustomSliderRenderer : SliderRenderer
    {
        CustomSlider slider = null;
        public CustomSliderRenderer(Context context) : base(context)
        {

        }


        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                slider = (CustomSlider)e.NewElement;

                //Control.Min = (int)slider.Minimum;
                //Control.Max = (int)slider.Maximum;
            }

            if (Control != null)
            {
                Control.StopTrackingTouch += Control_StopTrackingTouch;
                Control.ProgressChanged += Control_ProgressChanged;
            }
        }

        private void Control_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            //Set tag = true to know the button drawable is null
            if (slider != null)
            {
                Console.WriteLine("Android: Progress -> {0}, {1}", e.Progress, e.SeekBar.Max);
                slider.OnCustomValueChanged(slider, new ValueChangedEventArgs(0, e.Progress));
                slider.Value = ((double)(e.Progress) / e.SeekBar.Max) * slider.Maximum;
            }
        }
        private void Control_StopTrackingTouch(object sender, SeekBar.StopTrackingTouchEventArgs e)
        {
            Console.WriteLine("Slider up Stop: " + e.ToString());
            if (slider != null)
            {
                slider.OnStopedDrag(slider, e);
            }
        }
    }
}
