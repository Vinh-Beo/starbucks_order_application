using System;
using Xamarin.Forms;

namespace Converter
{
    public class BoolToStatusIconREConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return "Off.png";
            }
            bool __val = false;
            if (value.GetType() == typeof(bool))
            {
                __val = (bool)value;
            }
            else if (value.GetType() == typeof(int))
            {
                __val = (int)value > 0 ? true : false;
            }
            if (__val)
            {
                return "On.png";
            }
            else
            {
                return "Off.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return 0;
        }
    }
}
