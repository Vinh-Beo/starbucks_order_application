using System;
using Xamarin.Forms;

namespace Converter
{
    class BoolToLockUnLockImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
            {
                return "Lock.png";
            }
            else
            {
                return "Unlock.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return 0;
        }
    }
}
