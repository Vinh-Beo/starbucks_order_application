using System;
using Common;

namespace Converter
{
    class GroupEventEnumToIconConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string _NA = "Question_32px.png";
            if (value == null)
            {
                return _NA;
            }
            if (value.GetType() != typeof(GroupEventEnum))
            {
                return _NA;
            }
            GroupEventEnum _val = (GroupEventEnum)value;

            if (_val == GroupEventEnum.App)
            {
                return "App_32px.png";
            }
            else if (_val == GroupEventEnum.Device)
            {
                return "Manual_32px.png";
            }
            else if (_val == GroupEventEnum.GW)
            {
                return "Controller_32px.png";
            }
            else if (_val == GroupEventEnum.Server)
            {
                return "Server_32px.png";
            }
            else if (_val == GroupEventEnum.TP)
            {
                return "ThirdParty_32px.png";
            }
            else
            {
                return _NA;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
