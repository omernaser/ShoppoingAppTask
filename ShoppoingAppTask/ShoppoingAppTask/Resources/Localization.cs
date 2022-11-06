using ShoppoingAppTask.Helpers;
using ShoppoingAppTask.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ShoppoingAppTask.Resources
{
    public class Localization
    {
        static Localization()
        {
            var lang = GetLanguageState();

            Init(lang);
        }

        public static void Init(string lang = null)
        {
            if (lang == null)
                lang= Constants.CurrentAppLaguage;
            var appCulture = new CultureInfo(lang);
            Texts.Culture = appCulture;
        }

        #region "State"


        /// <summary>
        /// Set the App's current language, changes needs app restart in order to be applied.
        /// </summary>
        public static void ChangeApplicationLanguage(string lang)
        {
            Settings.SetString(Constants.AppLaguageKey, lang);
            Init(lang);
        }

        public static string GetLanguageState()
        {
            return Settings.GetString(Constants.AppLaguageKey);
        }



        #endregion
    }
}
