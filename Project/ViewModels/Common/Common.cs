using System;
using System.Text.RegularExpressions;

namespace Common
{
    public enum GroupEventEnum
    {
        App = 0,
        TP,
        GW,
        Device,
        Server,
        NA
    }

    public enum SaleStateEnum
    {
        Pause = 0,
        Start,
        Finish,
        Update,
        NA
    }

    public class InputChecker
    {
        public string ConvertToUnSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
    }
}
