using System;
using Project.Language;
using Xamarin.Forms;

namespace Converter
{
    class BoolToIsActivateOrNotStrConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return AppResources.NotActivate;
            }
            if (value.GetType() != typeof(bool))
            {
                return AppResources.NotActivate;
            }
            if ((bool)value)
            {
                return AppResources.IsActivate;
            }
            else
            {
                return AppResources.NotActivate;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return 0;
        }
    }
}
