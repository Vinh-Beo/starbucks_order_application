using Project.ViewModels.Common;
using System;
using System.Windows.Input;

namespace Common
{
    public class UserConstant
    {
        public const string True = "true";
        public const string False = "false";

        public const string TRUE = "True";
        public const string FALSE = "False";

        public const int APIVersion = 1;

        public const int WaitStepTime = 10; // 10 ms
        public const int WaitStepCnt = 300; // waiting 300 time of 10 ms
        public const int WaitCanView = 1000;

        public const int ServiceApiMaxReceived = 6553600;

        public const int ServiceApiReceiveTimeout = 60000; // sec
        public const int ServiceApiSendTimeout = 30000; // sec

        public const int MaxTimeoutService = 10000;

        /// <summary>
        /// version info
        /// </summary>
        public const int Version = 1;

        public const int SubVersion = 1;
        public const int BuildNumber = 2;
        public const string AppName = "Smart Starbucks Order";

        public const double Lat = 11.049248;
        public const double Long = 106.682697;

        // UI
        public const double MaxDialogWidth1 = 530;

        public const double MaxDialogWidthLocation = 100;
        public const double MaxDialogWidth2 = 650;

        public const double MinDialogHeight = 500;
        public const double MaxListViewHeight3 = 400;
        public const double MaxListViewHeight2 = 300;
        public const double MaxListViewHeight1 = 150;
        // map view
        public const double ZoomDF = 18;
        public const double ZoomDeviceDF = 19;

        public const int ZoomMaxDF = 24;
        public const int ZoomMinDF = 5;
        public const string MapCachePath = "MapCache";
        public const int GWMarkerWidth = 40;
        public const int GWMarkerHeight = 40;
        public const int PlusMarkerWidth = 32;
        public const int PlusMarkerHeight = 32;
        public const int SLDMarkerWidth = 32;
        public const int SLDMarkerHeight = 32;

        // Panel control
        public const int PnlCtrlWidth = 400;

        public const string ResourcePath = "Resources.SVG";
    }
    public class PositionCode
    {
        public const string ADMIN = "ADMIN";
        public const string OPERATOR = "OPERATOR";
        public const string MANTENANCE = "MANTENANCE";
    }

    public class CurrentUICulture
    {
        public const string VN = "vi-VN";
        public const string EN = "en";
        public const string EN_US = "en-US";
    }

    public enum TypeEnum
    {
        All,
        Coffee,
        Tea,
        Chocolate
    }
    public enum SizeEnum
    {
        Small,
        Medium,
        Large,
    }
}