using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.I18nManagers
{
    public class PlI18nManager : I18nManager
    {
        public PlI18nManager() : base("pl")
        {
            TranslationsMap = new Dictionary<string, I18nModel>()
            {
                { GetKey(Language, I18nTags.English), new I18nModel() { Language = Language, Tag = I18nTags.English, Content = "Angielski" } },
                { GetKey(Language, I18nTags.Polish), new I18nModel() { Language = Language, Tag = I18nTags.Polish, Content = "Polski" } },
            };
        }
    }
}
