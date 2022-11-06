using Plugin.Settings.Abstractions;
using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppoingAppTask.Helpers
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


        private static readonly string SettingsDefault = string.Empty;


        public static string GetString(string key)
        {
            return AppSettings.GetValueOrDefault(key, SettingsDefault);
        }
        public static void SetString(string key, string value)
        {
            AppSettings.AddOrUpdateValue(key, value);
        }

    }
}

