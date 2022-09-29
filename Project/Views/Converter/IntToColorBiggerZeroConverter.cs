using System;
using Xamarin.Forms;

namespace Converter
{
    public class IntToColorBiggerZeroConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((int)value > 0) ? Color.WhiteSmoke : Color.OrangeRed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
