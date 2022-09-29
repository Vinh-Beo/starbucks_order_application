using System;
using Project.Language;
using Xamarin.Forms;

namespace Converter
{
    public class BoolToOnlineOfflineFromStrConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool __val = (bool)value;
            if (__val)
            {
                return AppResources.OnlineFrom;
            }
            else
            {
                return AppResources.OfflineAt;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return 0;
        }
    }
}
