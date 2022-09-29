using System;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Threading;
using S3WAN.ViewModels.Main;
using Xamarin.Essentials;
using System.Collections.ObjectModel;
using Project.ViewModels.Common;

namespace Common
{
    class FormBase
    {
        public static DeviceInfo DeviceInfo = new DeviceInfo();

        public static bool IsDoServiceOS = false;

        public static MainViewModel MainViewModel;
        public static bool IsLogin = false;


        public static ObservableCollection<DetailSizeModel> Sizes = new ObservableCollection<DetailSizeModel>()
        {
            new DetailSizeModel()
            {
                Image = "Small.png",
                Size = SizeEnum.Small
            },
            new DetailSizeModel()
            {
                Image = "Medium.png",
                Size = SizeEnum.Medium
            },
            new DetailSizeModel()
            {
                Image = "Large.png",
                Size = SizeEnum.Large
            }
        };

        public static ObservableCollection<TypeEnumModel> Types = new ObservableCollection<TypeEnumModel>()
        {
            new TypeEnumModel()
            {
                Code = TypeEnum.All,
                IsSelected = true
            },
            new TypeEnumModel()
            {
                Code = TypeEnum.Chocolate,
                IsSelected = false
            },
            new TypeEnumModel()
            {
                Code = TypeEnum.Tea,
                IsSelected = false
            },
            new TypeEnumModel()
            {
                Code = TypeEnum.Coffee,
                IsSelected = false
            }
        };

        /// <summary>
        /// Calculate datetime from unix time
        /// </summary>
        /// <param name="unixTime"></param>
        /// <returns></returns>
        public static DateTime DateTimeFromUnixTime(long unixTime)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            return dtDateTime = dtDateTime.AddSeconds(unixTime).ToUniversalTime();
        }

        public static bool CheckMail(string email)
        {
            bool result = false;
            Regex regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            Match match = regex.Match(email);
            if (match.Success)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;

        }

        public static bool HasSpecicalChar(string input)
        {
            if (input.Contains("+") ||
                input.Contains("`") ||
                input.Contains("~") ||
                input.Contains("!") ||
                input.Contains("@") ||
                input.Contains("#") ||
                input.Contains("$") ||
                input.Contains("%") ||
                input.Contains("^") ||
                input.Contains("&") ||
                input.Contains("*") ||
                input.Contains("?") ||
                input.Contains(";") ||
                input.Contains("\"") ||
                input.Contains("\'") ||
                input.Contains("=") ||
                input.Contains("<") ||
                input.Contains(">"))
            {
                return true;
            }
            return false;
        }
        public static bool HasPasswordSpecicalChar(string input)
        {
            if (input.Contains("+") ||
                input.Contains("&") ||
                input.Contains("=") ||
                input.Contains("?") ||
                input.Contains(";") ||
                input.Contains("\"") ||
                input.Contains("\'"))
            {
                return true;
            }
            return false;
        }

        public static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }

        public static byte[] Zip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    //msi.CopyTo(gs);
                    CopyTo(msi, gs);
                }

                return mso.ToArray();
            }
        }
        public static byte[] Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    //gs.CopyTo(mso);
                    CopyTo(gs, mso);
                }

                return mso.ToArray();
            }
        }
        public static bool CheckLetter(string value)
        {
            bool result = false;
            int errorCounter = Regex.Matches(value, @"[a-zA-Z]").Count;

            if (value.Contains("`") ||
               value.Contains("~") ||
               value.Contains("!") ||
               value.Contains("@") ||
               value.Contains("#") ||
               value.Contains("$") ||
               value.Contains("%") ||
               value.Contains("^") ||
               value.Contains("&") ||
               value.Contains("*") ||
               value.Contains("(") ||
               value.Contains(")") ||
               value.Contains("_") ||
               value.Contains("-") ||
               value.Contains("+") ||
               value.Contains("='") ||
               value.Contains("|") ||
               value.Contains("\"") ||
               value.Contains("{") ||
               value.Contains("[") ||
               value.Contains("}") ||
               value.Contains("]") ||
               value.Contains(";") ||
               value.Contains(":") ||
               value.Contains("'") ||
               value.Contains("<") ||
               value.Contains(">") ||
               value.Contains("?"))
            {
                return true;
            }
            if (errorCounter > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

       
    }

    public class DeviceInfo
    {
        public double Height = 360;
        public double Width = 640;
        public double Density = 1;

        public DeviceInfo()
        {
            Density = DeviceDisplay.MainDisplayInfo.Density;
            Height = DeviceDisplay.MainDisplayInfo.Height;
            Width = DeviceDisplay.MainDisplayInfo.Width;
        }
    }
}
