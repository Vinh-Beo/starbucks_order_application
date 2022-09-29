using System;
using Xamarin.Forms;

namespace Converter
{
    class IntToInfoFailSuccessColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return Color.FromHex("#00623B");
            }
            if (value.GetType() != typeof(int))
            {
                return Color.FromHex("#00623B");
            }
            if ((int)value <= 0)
            {
                return Color.FromHex("#00623B");
            }
            else if ((int)value > 0)
            {
                return Color.WhiteSmoke;
            }
            else
            {
                return Color.FromHex("#00623B");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return 0;
        }
    }
}
