using System;
using Xamarin.Forms;

namespace Converter
{
    public class IntToStringHasMoreConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int _val = (int)value;
            if (_val == 0)
            {
                return string.Empty;
            }
            else if (_val > 0 && _val < 100)
            {
                return _val.ToString();
            }
            else
            {
                return "99+";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}