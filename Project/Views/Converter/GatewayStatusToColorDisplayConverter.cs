using System;
using System.Globalization;
using Common;
using Xamarin.Forms;

namespace Converter
{
    internal class GatewayStatusToColorDisplayConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return Color.DarkGray;
            }
            if (value.Length < 3)
            {
                return Color.DarkGray;
            }
            if (value[0] == null || value[1] == null)// || value[2] == null)
            {
                return Color.DarkGray;
            }
            //GatewayViewModel _gw = value[0] as GatewayViewModel;
            bool _isOnline = (bool)value[0];
            int _erRemain = (int)value[1];
            if (_erRemain == 0)
            {
                if (_isOnline)
                {
                    return Color.LightGreen;
                }
                else
                {
                    return Color.DarkGray;
                }
            }
            else
            {
                // Checking still error
                if (_erRemain > 0)
                {
                    return Color.OrangeRed;
                }
                else
                {
                    if (_isOnline)
                    {
                        return Color.LightGreen;
                    }
                    else
                    {
                        return Color.DarkGray;
                    }
                }
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}