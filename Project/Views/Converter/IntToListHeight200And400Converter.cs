using System;
using Xamarin.Forms;

namespace Converter
{
    public class IntToListHeight200And400Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int _val = (int)value;
            if (_val == 0)
            {
                return 0;
            }
            else if (_val > 0 && _val <= 2)
            {
                return 200;
            }
            else
            {
                return 400;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}