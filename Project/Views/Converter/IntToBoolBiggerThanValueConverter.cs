using System;
using Project.Language;
using Xamarin.Forms;

namespace Converter
{
    class IntToBoolBiggerThanValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || parameter == null)
            {
                return false;
            }
            if (value.GetType() != typeof(int))// || parameter.GetType() != typeof(int))
            {
                return false;
            }
            int _param = 0;
            try
            {
                _param = System.Convert.ToInt32(parameter);
            }
            catch (Exception)
            {
                return false;
            }

            if ((int)value > _param)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return 0;
        }
    }
}
