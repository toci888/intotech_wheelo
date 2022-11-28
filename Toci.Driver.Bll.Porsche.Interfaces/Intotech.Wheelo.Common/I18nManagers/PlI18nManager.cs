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
                { GetKey(Language, I18nTags.AccountExists), new I18nModel() { Language = Language, Tag = I18nTags.AccountExists, Content = "Konto istnieje." } },
                { GetKey(Language, I18nTags.Success), new I18nModel() { Language = Language, Tag = I18nTags.Success, Content = "Sukces." } },
                { GetKey(Language, I18nTags.FailVerifyingAccount), new I18nModel() { Language = Language, Tag = I18nTags.FailVerifyingAccount, Content = "Niepowodzenie weryfikacji konta." } },
            };
        }
    }
}
