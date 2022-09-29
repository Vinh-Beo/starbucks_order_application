using System;
using Common;
using Project.ViewModels.Common;

namespace Converter
{
    class SizeEnumStringConverter : Xamarin.Forms.IValueConverter
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
                return Project.Language.AppResources.Small;
            }
            else if (_val == SizeEnum.Medium)
            {
                return Project.Language.AppResources.Medium;
            }
            else if (_val == SizeEnum.Large)
            {
                return Project.Language.AppResources.Large;
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
