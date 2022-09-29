using System;
using Xamarin.Forms;

namespace Converter
{
    class BoolToFinishOrNotImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
            {
                return "OK_32px.png";
            }
            else
            {
                return "Close_32px.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return 0;
        }
    }
}
