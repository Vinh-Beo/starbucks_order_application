using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Common
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static string Config
        {
            get => AppSettings.GetValueOrDefault(nameof(Config), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Config), value);
        }
        public static string UserName
        {
            get => AppSettings.GetValueOrDefault(nameof(UserName), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(UserName), value);
        }
        public static string PassWord
        {
            get => AppSettings.GetValueOrDefault(nameof(PassWord), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(PassWord), value);
        }
        public static bool Remember
        {
            get => AppSettings.GetValueOrDefault(nameof(Remember), true);
            set => AppSettings.AddOrUpdateValue(nameof(Remember), value);
        }
    }
}
