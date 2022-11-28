using Intotech.Wheelo.Common.I18nManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common
{
    public static class I18nTranslation
    {
        private static string Language = "pl";
        //private static I18nManager i18NManager = new I18nManager(Language);

        private static Dictionary<string, I18nManager> LanguageManagers = new Dictionary<string, I18nManager>()
        {
            { "en", new EnI18nManager() },
            { "pl", new PlI18nManager() },
        };

        static I18nTranslation()
        {
        }


        public static void SetLanguage(string language)
        {
            Language = language;
            //i18NManager = new I18nManager(Language);
        }

        public static string Translation(string tag)
        {
            I18nModel model = LanguageManagers.ContainsKey(Language) ? LanguageManagers[Language].GetTranslation(tag) : null;

            return model != null ? model.Content : tag;
        }
    }
}
