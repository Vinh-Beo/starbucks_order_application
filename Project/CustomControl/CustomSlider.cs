using System;
using Xamarin.Forms;

namespace CustomControl
{
    public class CustomSlider : Slider
    {
        public CustomSlider()
        {
        }

        public event EventHandler StopedDraging;
        public event EventHandler CustomValueChanged;

        public void OnStopedDrag(Element element, EventArgs args)
        {
            StopedDraging?.Invoke(this, args);
        }
        public void OnCustomValueChanged(Element element, ValueChangedEventArgs args)
        {
            // Get value and max value
            CustomValueChanged?.Invoke(this, args);
        }
    }
}
