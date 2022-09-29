using System;
using Xamarin.Forms;

namespace Converter
{
    class ByteSizeToKBSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return 0;
            }
            if (value.GetType() != typeof(long))
            {
                return 0;
            }
            long _vm = (long)value;
            return _vm / 1024;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return 0;
        }
    }
}
