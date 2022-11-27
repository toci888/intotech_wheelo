using Intotech.Wheelo.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common
{
    public class I18nManager
    {
        private static string Language = "pl";

        protected Dictionary<string, I18nModel> TranslationsMap = new Dictionary<string, I18nModel>()
        {
            { GetKey(Language, I18nTags.English), new I18nModel() { Language = Language, Tag = I18nTags.English, Content = "Angielski" } },
            { GetKey(Language, I18nTags.Polish), new I18nModel() { Language = Language, Tag = I18nTags.Polish, Content = "Polski" } },
        };

        private static string GetKey(string lang, string tag)
        {
            return string.Format("{0}_{1}");
        }

        public virtual I18nModel GetTranslation(string language, string tag)
        {
            string key = GetKey(language, tag);
            string rescueKey = GetKey(Language, tag);

            return TranslationsMap.ContainsKey(key) ? TranslationsMap[key] : (TranslationsMap.ContainsKey(rescueKey) ? TranslationsMap[rescueKey] : null);
        }
    }
}
