using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppoingAppTask.Helpers
{
    public class Constants
    {
        public static int PageSize = 30;
        public static string AppLaguageKey =>"App_Language";
        public static string UserNameKey => "User_Name_Key";
        public static string CurrentAppLaguage => string.IsNullOrEmpty(Settings.GetString(AppLaguageKey)) ? "en" : Settings.GetString("App_Language");
        public bool IsArabic => !CurrentAppLaguage.Equals("en");
    }
}
