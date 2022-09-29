using System;
using Xamarin.Forms;

namespace Converter
{
    class IntToOnOffForegroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return Color.DarkGray;
            }
            if (value.GetType() != typeof(int))
            {
                return Color.DarkGray;
            }
            if ((int)value > 0)
            {
                return Color.OrangeRed;
            }
            else
            {
                return Color.DarkGray;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return 0;
        }
    }
}
