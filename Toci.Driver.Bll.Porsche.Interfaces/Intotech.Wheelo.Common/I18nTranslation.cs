using Intotech.Wheelo.Common.I18nManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common
{
    public class I18nTranslation
    {
        private static string Language = "pl";
        //private static I18nManager i18NManager = new I18nManager(Language);

        protected static Dictionary<string, I18nManager> LanguageManagers = new Dictionary<string, I18nManager>()
        {
            { "en", new EnI18nManager() },
            { "pl", new PlI18nManager() },
        };



        public static void SetLanguage(string language)
        {
            Language = language;
            //i18NManager = new I18nManager(Language);
        }

        public static string Translation(string tag)
        {
            I18nModel model = LanguageManagers[Language].GetTranslation(tag);

            return model != null ? model.Content : tag;
        }
    }
}
