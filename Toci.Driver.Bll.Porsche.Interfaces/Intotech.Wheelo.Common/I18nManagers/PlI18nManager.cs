using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.I18nManagers
{
    public class PlI18nManager : I18nManager
    {
        public PlI18nManager() : base(I18nTags.LanguageCodePl)
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
                { GetKey(Language, I18nTags.DataAlreadyExistInDatabase), new I18nModel() { Language = Language, Tag = I18nTags.DataAlreadyExistInDatabase, Content = "Dane już istnieją w bazie danych."} },
                { GetKey(Language, I18nTags.DefaultModeCreated), new I18nModel() { Language = Language, Tag = I18nTags.DefaultModeCreated, Content = "Domyślny tryb stworzony."} },
                { GetKey(Language, I18nTags.ErrorPleaseLogInToApp), new I18nModel() { Language = Language, Tag = I18nTags.ErrorPleaseLogInToApp, Content = "Błąd. Zaloguj się proszę do aplikacji."} },
                { GetKey(Language, I18nTags.EmailDoesNotExist), new I18nModel() { Language = Language, Tag = I18nTags.EmailDoesNotExist, Content = "Adres e-mail nie istnieje."} },
                { GetKey(Language, I18nTags.FriendshipNotFound), new I18nModel() { Language = Language, Tag = I18nTags.FriendshipNotFound, Content = "Znajomość nie odnaleziona."} },
               /* { GetKey(Language, I18nTags.LanguageCodeEn), new I18nModel() { Language = Language, Tag = I18nTags.LanguageCodeEn, Content = "Kod języka: angielski."} },
                { GetKey(Language, I18nTags.LanguageCodePl), new I18nModel() { Language = Language, Tag = I18nTags.LanguageCodePl, Content = "Kod języka: polski."} }, */
                { GetKey(Language, I18nTags.NoData), new I18nModel() { Language = Language, Tag = I18nTags.NoData, Content = "Brak danych."} },
                { GetKey(Language, I18nTags.NoWorkTripData), new I18nModel() { Language = Language, Tag = I18nTags.NoWorkTripData, Content = "Brak danych podróży."} },
                { GetKey(Language, I18nTags.PasswordChangeSuccess), new I18nModel() { Language = Language, Tag = I18nTags.PasswordChangeSuccess, Content = "Udało się zmienić hasło."} },
                { GetKey(Language, I18nTags.PleaseConfirmYourWheeloAccountRegistration), new I18nModel() { Language = Language, Tag = I18nTags.PleaseConfirmYourWheeloAccountRegistration, Content = "Potwierdź proszę rejestrację swojego konta Wheelo."} },
                { GetKey(Language, I18nTags.PleaseLogIn), new I18nModel() { Language = Language, Tag = I18nTags.PleaseLogIn, Content = "Proszę, zaloguj się."} },
                { GetKey(Language, I18nTags.RefreshTokenExpiredPleaseLogIn), new I18nModel() { Language = Language, Tag = I18nTags.RefreshTokenExpiredPleaseLogIn, Content = "Bieżący token wygasł. Proszę, zaloguj się."} },
                { GetKey(Language, I18nTags.UnderAttack), new I18nModel() { Language = Language, Tag = I18nTags.UnderAttack, Content = "Jesteś atakowany"} },
                { GetKey(Language, I18nTags.WrongData), new I18nModel() { Language = Language, Tag = I18nTags.WrongData, Content = "Błędne dane."} },
                { GetKey(Language, I18nTags.WrongOperations), new I18nModel() { Language = Language, Tag = I18nTags.WrongOperations, Content = "Błędne działanie."} },
                
                //I18nTags 

            };
        }
    }
}
