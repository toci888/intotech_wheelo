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
                { GetKey(Language, I18nTags.Portugese), new I18nModel() { Language = Language, Tag = I18nTags.Portugese, Content = "Portugalski"} },
                { GetKey(Language, I18nTags.Ukrainian), new I18nModel() { Language = Language, Tag = I18nTags.Ukrainian, Content = "Ukraiński"} },
                { GetKey(Language, I18nTags.Italian), new I18nModel() { Language = Language, Tag = I18nTags.Italian, Content = "Włoski"} },
                { GetKey(Language, I18nTags.German), new I18nModel() { Language = Language, Tag = I18nTags.German, Content = "Niemiecki"} },
                { GetKey(Language, I18nTags.EmailIsNotConfirmed), new I18nModel() { Language = Language, Tag = I18nTags.EmailIsNotConfirmed, Content = "E-mail jest niepotwierdzony."} },
                { GetKey(Language, I18nTags.AccountNotFound), new I18nModel() { Language = Language, Tag = I18nTags.AccountNotFound, Content = "Konta nie znaleziono."} },
                { GetKey(Language, I18nTags.Dutch), new I18nModel() { Language = Language, Tag = I18nTags.Dutch, Content = "Duński"} },
                { GetKey(Language, I18nTags.Error), new I18nModel() { Language = Language, Tag = I18nTags.Error, Content = "Błąd"} },
                { GetKey(Language, I18nTags.French), new I18nModel() { Language = Language, Tag = I18nTags.French, Content = "Francuski"} },
                { GetKey(Language, I18nTags.FailedToAddInformation), new I18nModel() { Language = Language, Tag = I18nTags.FailedToAddInformation, Content = "Nie udało się dodać informacji."} },
                { GetKey(Language, I18nTags.Swedish), new I18nModel() { Language = Language, Tag = I18nTags.Swedish, Content = "Szwedzki"} },
                { GetKey(Language, I18nTags.Spanish), new I18nModel() { Language = Language, Tag = I18nTags.Spanish, Content = "Hiszpański"} },
                

            };
        }
    }
}
