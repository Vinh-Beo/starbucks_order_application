using System;
using Xamarin.Forms;

namespace CustomControl
{
    public class ImageColor : View
    {
        #region ForegroundProperty

        public static readonly BindableProperty ForegroundProperty = BindableProperty.Create(nameof(Foreground), typeof(Color), typeof(ImageColor), default(Color));

        public Color Foreground
        {
            get
            {
                return (Color)GetValue(ForegroundProperty);
            }
            set
            {
                SetValue(ForegroundProperty, value);
            }
        }

        #endregion

        #region SourceProperty

        public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(string), typeof(ImageColor), default(string));

        public string Source
        {
            get
            {
                return (string)GetValue(SourceProperty);
            }
            set
            {
                SetValue(SourceProperty, value);
            }
        }

        #endregion
    }
}
