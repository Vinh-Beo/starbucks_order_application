using System;
using Project.Language;
using Xamarin.Forms;

namespace Converter
{
    class IntToColorBiggerThanValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || parameter == null)
            {
                return Color.Gray;
            }
            if (value.GetType() != typeof(int) || parameter.GetType() != typeof(int))
            {
                return Color.Gray;
            }
            if (((int)value < ((int)parameter * 3) / 4))
            {
                return Color.WhiteSmoke;
            }
            else if (((int)value >= ((int)parameter * 3) / 4) && ((int)value < ((int)parameter)))
            {
                return Color.Orange;
            }
            else
            {
                return Color.Red;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return 0;
        }
    }
}
