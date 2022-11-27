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
        private static I18nManager i18NManager = new I18nManager();

        public static void SetLanguage(string language)
        {
            Language = language;
        }

        public static string Translation(string tag)
        {
            I18nModel model = i18NManager.GetTranslation(Language, tag);

            return model != null ? model.Content : tag;
        }
    }
}
