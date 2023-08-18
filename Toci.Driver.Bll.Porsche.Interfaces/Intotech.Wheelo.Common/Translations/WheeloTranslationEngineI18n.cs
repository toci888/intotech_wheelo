using Intotech.Common;

namespace Intotech.Wheelo.Common.Translations
{
    public class WheeloTranslationEngineI18n : TranslationEngineI18n
    {
        public WheeloTranslationEngineI18n()
        {
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                { "en-GB", new Dictionary<string, string>()
                        {
                            {"_english", "English"},

                            {"_polish", "Polish"},

                            {"_success", "Success"},

                            {"_failVerifyingAccount", "Failed to verify an account."},

                            {"_accountExists", "Account already exists."},

                            {"_ukrainian", "Ukrainian"},

                            {"_italian", "Italian"},

                            {"_german", "German"},

                            {"_emailIsNotConfirmed", "E-mail is not confirmed."},

                            {"_accountNotFound", "Account is not found."},

                            {"_dutch", "Dutch"},

                            {"_portugese", "Portugese"},

                            {"_french", "French"},

                            {"_failedToAddInformation", "Failed to add information."},

                            {"_spanish", "Spanish"},

                            {"_swedish", "Swedish"},

                            {"_error", "Error"},
                        }
                }, 
                { "pl-PL", new Dictionary<string, string>()
                        {
                            {"_english", "Angielski"},

                            {"_polish", "Polski"},

                            {"_accountExists", "Konto istnieje."},

                            {"_success", "Sukces."},

                            {"_failVerifyingAccount", "Niepowodzenie weryfikacji konta."},

                            {"_portugese", "Portugalski"},

                            {"_ukrainian", "Ukraiński"},

                            {"_italian", "Włoski"},

                            {"_german", "Niemiecki"},

                            {"_emailIsNotConfirmed", "E-mail jest niepotwierdzony."},

                            {"_accountNotFound", "Konta nie znaleziono."},

                            {"_dutch", "Duński"},

                            {"_error", "Błąd"},

                            {"_french", "Francuski"},

                            {"_failedToAddInformation", "Nie udało się dodać informacji."},

                            {"_swedish", "Szwedzki"},

                            {"_spanish", "Hiszpański"},

                            {"_dataAlreadyExistInDatabase", "Dane już istnieją w bazie danych."},

                            {"_defaultModeCreated", "Domyślny tryb stworzony."},

                            {"_errorPleaseLogInToApp", "Błąd. Zaloguj się proszę do aplikacji."},

                            {"_emailDoesNotExist", "Adres e-mail nie istnieje."},

                            {"_friendshipNotFound", "Znajomość nie odnaleziona."},

                            {"_noData", "Brak danych."},

                            {"_noWorkTripData", "Brak danych podróży."},

                            {"_passwordChangedSuccessfully", "Udało się zmienić hasło."},

                            {"_pleaseConfirmYourWheeloAccountRegistration", "Potwierdź proszę rejestrację swojego konta Wheelo."},

                            {"_pleaseLogIn", "Proszę, zaloguj się."},

                            {"_refreshTokenExpiredPleaseLogIn", "Bieżący token wygasł. Proszę, zaloguj się."},

                            {"_youSeemRobot", "Jesteś atakowany"},

                            {"_wrongData", "Błędne dane."},

                            {"_wrongOperations", "Błędne działanie."},
                        }
                }
            };
        }
    }
}
