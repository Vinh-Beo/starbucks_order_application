using System;
using CustomControl;
using Project.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomControl.CustomSlider), typeof(CustomSliderRenderer))]
namespace Project.iOS
{
    public class CustomSliderRenderer : SliderRenderer
    {
        CustomSlider slider = null;
        public CustomSliderRenderer()
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                slider = (CustomSlider)e.NewElement;
                Control.TouchUpInside += Control_TouchUpInside;
                Control.TouchUpOutside += Control_TouchUpOutside;
                Control.ValueChanged += Control_ValueChanged;
            }
        }

        private void Control_ValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Slider up change: " + e.ToString());
            if (slider != null)
            {
                slider.Value = (double)Control.Value;
            }
        }

        private void Control_TouchUpOutside(object sender, EventArgs e)
        {
            Console.WriteLine("Slider up Outside: " + e.ToString());
            if (slider != null)
            {
                slider.OnStopedDrag(slider, e);
            }
        }

        private void Control_TouchUpInside(object sender, EventArgs e)
        {
            Console.WriteLine("Slider up: " + e.ToString());
            if (slider != null)
            {
                slider.OnStopedDrag(slider, e);
            }
        }

        //private void Control_Touch(object sender, TouchEventArgs e)
        //{
        //    var sliderSeek = (SeekBar)sender;

        //    if (e.Event.Action == MotionEventActions.Up)
        //    {
        //        slider.OnStopedDrag(slider.Value.ToString());
        //    }
        //}
    }
}

