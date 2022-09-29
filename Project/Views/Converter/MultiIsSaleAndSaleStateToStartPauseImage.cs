using Common;
using Project.Language;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace Converter
{
    class MultiIsSaleAndSaleStateToStartPauseImage : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return "";
            }
            if (value.Length < 2)
            {
                return "";
            }
            if (value[0] == null || value[0].GetType() != typeof(bool) || value[1] == null || value[1].GetType() != typeof(SaleStateEnum))
            {
                return "";
            }

            bool _isSaleProcess = (bool)value[0];
            SaleStateEnum _state = (SaleStateEnum)value[1];
            if (!_isSaleProcess)
            {
                return "Start_32px.png";
            }
            else
            {
                if (_state == SaleStateEnum.Pause || _state == SaleStateEnum.Finish)
                {
                    return "Start_32px.png";
                }
                else
                {
                    return "Pause_32px.png";
                }
            }
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
