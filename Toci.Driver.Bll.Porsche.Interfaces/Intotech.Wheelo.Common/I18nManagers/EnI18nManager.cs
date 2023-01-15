using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.I18nManagers
{
    public class EnI18nManager : I18nManager
    {
        public EnI18nManager() : base(I18nTags.LanguageCodeEn)
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
                { GetKey(Language, I18nTags.DataAlreadyExistInDatabase), new I18nModel() { Language = Language, Tag = I18nTags.DataAlreadyExistInDatabase, Content = "Data already exist in the database."} },
                { GetKey(Language, I18nTags.DefaultModeCreated), new I18nModel() { Language = Language, Tag = I18nTags.DefaultModeCreated, Content = "Default mode created."} },
                { GetKey(Language, I18nTags.ErrorPleaseLogInToApp), new I18nModel() { Language = Language, Tag = I18nTags.ErrorPleaseLogInToApp, Content = "Error. Please log in to application."} },
                { GetKey(Language, I18nTags.EmailDoesNotExist), new I18nModel() { Language = Language, Tag = I18nTags.EmailDoesNotExist, Content = "E-mail address doesn't exist."} },
                { GetKey(Language, I18nTags.FriendshipNotFound), new I18nModel() { Language = Language, Tag = I18nTags.FriendshipNotFound, Content = "Friendship not found."} },
               /* { GetKey(Language, I18nTags.LanguageCodeEn), new I18nModel() { Language = Language, Tag = I18nTags.LanguageCodeEn, Content = "Kod języka: angielski."} },
                { GetKey(Language, I18nTags.LanguageCodePl), new I18nModel() { Language = Language, Tag = I18nTags.LanguageCodePl, Content = "Kod języka: polski."} }, */
                { GetKey(Language, I18nTags.NoData), new I18nModel() { Language = Language, Tag = I18nTags.NoData, Content = "No data."} },
                { GetKey(Language, I18nTags.NoWorkTripData), new I18nModel() { Language = Language, Tag = I18nTags.NoWorkTripData, Content = "No work trip data."} },
                { GetKey(Language, I18nTags.PasswordChangeSuccess), new I18nModel() { Language = Language, Tag = I18nTags.PasswordChangeSuccess, Content = "Password change success."} },
                { GetKey(Language, I18nTags.PleaseConfirmYourWheeloAccountRegistration), new I18nModel() { Language = Language, Tag = I18nTags.PleaseConfirmYourWheeloAccountRegistration, Content = "Please, confirm your Wheelo account registration."} },
                { GetKey(Language, I18nTags.PleaseLogIn), new I18nModel() { Language = Language, Tag = I18nTags.PleaseLogIn, Content = "Please, log in."} },
                { GetKey(Language, I18nTags.RefreshTokenExpiredPleaseLogIn), new I18nModel() { Language = Language, Tag = I18nTags.RefreshTokenExpiredPleaseLogIn, Content = "Refresh token expired. Please, log in."} },
                { GetKey(Language, I18nTags.UnderAttack), new I18nModel() { Language = Language, Tag = I18nTags.UnderAttack, Content = "Under attack"} },
                { GetKey(Language, I18nTags.WrongData), new I18nModel() { Language = Language, Tag = I18nTags.WrongData, Content = "Wrong data."} },
                { GetKey(Language, I18nTags.WrongOperations), new I18nModel() { Language = Language, Tag = I18nTags.WrongOperations, Content = "Wrong operations."} },
            };
        }
    }
}
