using System;
namespace Converter
{
    public class IntToStringNumberSignConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int _value = (int)value;
            if (_value == 0)
            {
                return "0";
            }
            string __ret = "+";
            if (_value < 0)
            {
                __ret = "-";
            }

            _value = Math.Abs(_value);
            if (_value < 10)
            {
                __ret += ("0" + _value.ToString());
            }
            else
            {
                __ret += (_value.ToString());
            }
            return __ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
