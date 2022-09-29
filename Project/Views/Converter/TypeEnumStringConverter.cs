using System;
using Common;
using Project.ViewModels.Common;

namespace Converter
{
    class TypeEnumStringConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string _type = "All";
            if (value == null)
            {
                return _type;
            }
            if (value.GetType() != typeof(TypeEnum))
            {
                return _type;
            }
            TypeEnum _val = (TypeEnum)value;

            if (_val == TypeEnum.Chocolate)
            {
                return "Chocolate";
            }
            else if (_val == TypeEnum.Tea)
            {
                return "Tea";
            }
            else if (_val == TypeEnum.Coffee)
            {
                return "Coffee";
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
