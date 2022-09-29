using System;
using Project.Language;
using Xamarin.Forms;

namespace Converter
{
    class BoolToIsOnlineOfflineStrConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return AppResources.Offline;
            }
            if (value.GetType() != typeof(bool))
            {
                return AppResources.Offline;
            }
            if ((bool)value)
            {
                return AppResources.Online;
            }
            else
            {
                return AppResources.Offline;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return 0;
        }
    }
}
