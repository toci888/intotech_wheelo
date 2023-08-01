using Intotech.Wheelo.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common
{
    public abstract class I18nManager
    {
        public string Language; // = "pl";

        public Dictionary<string, I18nModel> TranslationsMap;

        protected I18nManager(string language) 
        {
            Language = language;

            //            TranslationsMap = new Dictionary<string, I18nModel>()
            //            {
            //               { GetKey(Language, I18nTags.English), new I18nModel() { Language = Language, Tag = I18nTags.English, Content = "Angielski" } },
            //               { GetKey(Language, I18nTags.Polish), new I18nModel() { Language = Language, Tag = I18nTags.Polish, Content = "Polski" } },
            //          };
        }

        protected string GetKey(string lang, string tag)
        {
            return string.Format("{0}_{1}", lang, tag);
        }

        public virtual I18nModel GetTranslation(string tag)
        {
            string key = GetKey(Language, tag);

            return TranslationsMap.ContainsKey(key) ? TranslationsMap[key] : null;
        }
    }
}
