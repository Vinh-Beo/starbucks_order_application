using System;
using Xamarin.Forms;

namespace Converter
{
    public class IntToStringHasMore9Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int _val = (int)value;
            if (_val == 0)
            {
                return string.Empty;
            }
            else if (_val > 0 && _val < 10)
            {
                return _val.ToString();
            }
            else
            {
                return "9+";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}