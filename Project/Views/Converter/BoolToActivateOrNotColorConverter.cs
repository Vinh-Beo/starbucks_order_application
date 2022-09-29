using System;
using Project.Language;
using Xamarin.Forms;

namespace Converter
{
    class BoolToActivateOrNotColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return Color.Gray;
            }
            if (value.GetType() != typeof(bool))
            {
                return Color.Gray;
            }
            if ((bool)value)
            {
                return Color.WhiteSmoke;
            }
            else
            {
                return Color.Gray;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return 0;
        }
    }
}
