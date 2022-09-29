using System;
using Xamarin.Forms;

namespace Converter
{
    class IntToInfoFailSuccessImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return "Question_32px.png";
            }
            if (value.GetType() != typeof(int))
            {
                return "Question_32px.png";
            }
            if ((int)value == 0)
            {
                return "Play_32px.png";
            }
            else if ((int)value == 1)
            {
                return "Close_32px.png";
            }
            else
            {
                return "OK_32px.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return 0;
        }
    }
}
