using System;
using Xamarin.Forms;

namespace Converter
{
    public class BoolToIsVirtualLineColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value == true ? Color.Teal : Color.WhiteSmoke;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
