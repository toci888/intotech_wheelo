using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.I18nManagers
{
    public class EnI18nManager : I18nManager
    {
        public EnI18nManager() : base("en")
        {
            TranslationsMap = new Dictionary<string, I18nModel>()
            {
                { GetKey(Language, I18nTags.English), new I18nModel() { Language = Language, Tag = I18nTags.English, Content = "English" } },
                { GetKey(Language, I18nTags.Polish), new I18nModel() { Language = Language, Tag = I18nTags.Polish, Content = "Polish" } },
            };
        }
    }
}
