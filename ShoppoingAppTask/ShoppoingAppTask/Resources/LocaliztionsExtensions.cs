using ShoppoingAppTask.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ShoppoingAppTask.Resources
{
    public static class LocaliztionsExtensions
    {
        public static string Localize(this string key)
        {
            var translation = GetString(key);
            translation = LocalizeInternal(key, translation, false);
            return translation;
        }
        public static string GetString(string key)
        {
            return Texts.ResourceManager.GetString(key, Texts.Culture);
        }
        public static string Localize(this string key, decimal number)
        {
            string translation = null;

            if (string.IsNullOrWhiteSpace(translation))
            {
                translation = GetString(key);
            }

            translation = LocalizeInternal(key, translation, false);

            translation = string.Format(translation, number);

            return translation;
        }
        private static string LocalizeInternal(string key, string translation, bool ignoreKeyNotFound = false)
        {
            if (translation == null)
            {
#if DEBUG
                if (!ignoreKeyNotFound)
                {
                    Console.WriteLine($"Key '{key}' was not found in resources files.");
                    return "MISSING_RESX_KEY";
                }
                else
                {
                    // HACK: returns the key, which GETS DISPLAYED TO THE USER
                    return key.Replace("__", "{").Replace('_', '}');
                }
#else
                return key.Replace("__", "{").Replace('_', '}');
#endif
            }

            return translation;
        }

    }
}
