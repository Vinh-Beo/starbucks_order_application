using System;
using Xamarin.Forms;

namespace Converter
{
    class IntToLightStatusImgConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return "SLD_00.png";
            }
            int __val = (int)value;
            if (__val <= 0)
            {
                return "SLD_00.png";
            }
            else if (__val > 0 && __val < 10)
            {
                return "SLD_10.png";
            }
            else if (__val >= 10 && __val < 20)
            {
                return "SLD_20.png";
            }
            else if (__val >= 20 && __val < 30)
            {
                return "SLD_30.png";
            }
            else if (__val >= 30 && __val < 40)
            {
                return "SLD_40.png";
            }
            else if (__val >= 40 && __val < 50)
            {
                return "SLD_50.png";
            }
            else if (__val >= 50 && __val < 60)
            {
                return "SLD_60.png";
            }
            else if (__val >= 60 && __val < 70)
            {
                return "SLD_70.png";
            }
            else if (__val >= 70 && __val < 80)
            {
                return "SLD_80.png";
            }
            else if (__val >= 80 && __val < 90)
            {
                return "SLD_90.png";
            }
            else
            {
                return "SLD_100.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return 0;
        }
    }
}
