using System;
using Xamarin.Forms;

namespace Converter
{
    public class IntToNotColorBiggerZeroConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((int)value > 0) ? Color.Red : Color.FromHex("#00623B");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
