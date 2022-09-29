using System;
using Xamarin.Forms;

namespace Converter
{
    public class BoolToChangeBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value == true ? Color.FromHex("#00623B") : Color.FromHex("#F2F2F2");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
