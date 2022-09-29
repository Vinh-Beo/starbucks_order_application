using Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Converter
{
    internal class DoubleToConvertFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return 0;
            }
            if (value.GetType() != typeof(double))
            {
                return 0;
            }
            double _val = Math.Round((double)value, 3);
            if (_val > 1000)
            {
                return String.Format("{0:n0}", _val);
            }
            return _val.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
