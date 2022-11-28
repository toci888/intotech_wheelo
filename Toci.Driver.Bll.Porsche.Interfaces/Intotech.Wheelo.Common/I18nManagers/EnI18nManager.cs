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
                { GetKey(Language, I18nTags.Success), new I18nModel() { Language = Language, Tag = I18nTags.Success, Content = "Success" } },
                { GetKey(Language, I18nTags.FailVerifyingAccount), new I18nModel() { Language = Language, Tag = I18nTags.FailVerifyingAccount, Content = "Failed to verify an account." } },
                { GetKey(Language, I18nTags.AccountExists), new I18nModel() { Language = Language, Tag = I18nTags.AccountExists, Content = "Account already exists." } },
                { GetKey(Language, I18nTags.Ukrainian), new I18nModel() { Language = Language, Tag = I18nTags.Ukrainian, Content = "Ukrainian" } },
                { GetKey(Language, I18nTags.Italian), new I18nModel() { Language = Language, Tag = I18nTags.Italian, Content = "Italian" } },
                { GetKey(Language, I18nTags.German), new I18nModel() { Language = Language, Tag = I18nTags.German, Content = "German" } },
                { GetKey(Language, I18nTags.EmailIsNotConfirmed), new I18nModel() { Language = Language, Tag = I18nTags.EmailIsNotConfirmed, Content = "E-mail is not confirmed." } },
                { GetKey(Language, I18nTags.AccountNotFound), new I18nModel() { Language = Language, Tag = I18nTags.AccountNotFound, Content = "Account is not found." } },
                { GetKey(Language, I18nTags.Dutch), new I18nModel() { Language = Language, Tag = I18nTags.Dutch, Content = "Dutch" } },
                { GetKey(Language, I18nTags.Portugese), new I18nModel() { Language = Language, Tag = I18nTags.Portugese, Content = "Portugese" } },
                { GetKey(Language, I18nTags.French), new I18nModel() { Language = Language, Tag = I18nTags.French, Content = "French" } },
                { GetKey(Language, I18nTags.FailedToAddInformation), new I18nModel() { Language = Language, Tag = I18nTags.FailedToAddInformation, Content = "Failed to add information." } },
                { GetKey(Language, I18nTags.Spanish), new I18nModel() { Language = Language, Tag = I18nTags.Spanish, Content = "Spanish" } },
                { GetKey(Language, I18nTags.Swedish), new I18nModel() { Language = Language, Tag = I18nTags.Swedish, Content = "Swedish" } },
                { GetKey(Language, I18nTags.Error), new I18nModel() { Language = Language, Tag = I18nTags.Error, Content = "Error" } },

            };
        }
    }
}
