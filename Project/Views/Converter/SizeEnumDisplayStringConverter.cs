using System;
using Common;
using Project.ViewModels.Common;

namespace Converter
{
    class SizeEnumDisplayStringConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string _type = "";
            if (value == null)
            {
                return _type;
            }
            if (value.GetType() != typeof(SizeEnum))
            {
                return _type;
            }
            SizeEnum _val = (SizeEnum)value;

            if (_val == SizeEnum.Small)
            {
                return "(S)";
            }
            else if (_val == SizeEnum.Medium)
            {
                return "(M)";
            }
            else if (_val == SizeEnum.Large)
            {
                return "(L)";
            }
            else
            {
                return _type;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
