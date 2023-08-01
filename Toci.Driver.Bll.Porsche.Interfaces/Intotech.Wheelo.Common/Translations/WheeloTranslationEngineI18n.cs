using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.Translations
{
    internal class WheeloTranslationEngineI18n
    {
        protected Dictionary<string, Dictionary<string, string>> ApplicationTranslationData;      
        public WheeloTranslationEngineI18n(Dictionary<string, Dictionary<string, string>> applicationTranslationData)
        {
            ApplicationTranslationData = applicationTranslationData;
            
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"en", new Dictionary<string, string> 
                    {
                        {"_english", "English"}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"en", new Dictionary<string, string> 
                    {
                        {"_polish", "Polish"}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"en", new Dictionary<string, string> 
                    {
                        {"_success", "Success"}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"en", new Dictionary<string, string> 
                    {
                        {"_failVerifyingAccount", "Failed to verify an account."}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"en", new Dictionary<string, string> 
                    {
                        {"_accountExists", "Account already exists."}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"en", new Dictionary<string, string> 
                    {
                        {"_ukrainian", "Ukrainian"}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"en", new Dictionary<string, string> 
                    {
                        {"_italian", "Italian"}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"en", new Dictionary<string, string> 
                    {
                        {"_german", "German"}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"en", new Dictionary<string, string> 
                    {
                        {"_emailIsNotConfirmed", "E-mail is not confirmed."}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"en", new Dictionary<string, string> 
                    {
                        {"_accountNotFound", "Account is not found."}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"en", new Dictionary<string, string> 
                    {
                        {"_dutch", "Dutch"}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"en", new Dictionary<string, string> 
                    {
                        {"_portugese", "Portugese"}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"en", new Dictionary<string, string> 
                    {
                        {"_french", "French"}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"en", new Dictionary<string, string> 
                    {
                        {"_failedToAddInformation", "Failed to add information."}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"en", new Dictionary<string, string> 
                    {
                        {"_spanish", "Spanish"}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"en", new Dictionary<string, string> 
                    {
                        {"_swedish", "Swedish"}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"en", new Dictionary<string, string> 
                    {
                        {"_error", "Error"}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_english", "Angielski"}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_polish", "Polski"}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_accountExists", "Konto istnieje."}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_success", "Sukces."}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_failVerifyingAccount", "Niepowodzenie weryfikacji konta."}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_portugese", "Portugalski"}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_ukrainian", "Ukraiński"}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_italian", "Włoski"}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_german", "Niemiecki"}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_emailIsNotConfirmed", "E-mail jest niepotwierdzony."}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_accountNotFound", "Konta nie znaleziono."}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_dutch", "Duński"}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_error", "Błąd"}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_french", "Francuski"}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_failedToAddInformation", "Nie udało się dodać informacji."}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_swedish", "Szwedzki"}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_spanish", "Hiszpański"}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_dataAlreadyExistInDatabase", "Dane już istnieją w bazie danych."}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_defaultModeCreated", "Domyślny tryb stworzony."}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_errorPleaseLogInToApp", "Błąd. Zaloguj się proszę do aplikacji."}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_emailDoesNotExist", "Adres e-mail nie istnieje."}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_friendshipNotFound", "Znajomość nie odnaleziona."}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_noData", "Brak danych."}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_noWorkTripData", "Brak danych podróży."}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_passwordChangedSuccessfully", "Udało się zmienić hasło."}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_pleaseConfirmYourWheeloAccountRegistration", "Potwierdź proszę rejestrację swojego konta Wheelo."}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_pleaseLogIn", "Proszę, zaloguj się."}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_refreshTokenExpiredPleaseLogIn", "Bieżący token wygasł. Proszę, zaloguj się."}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_youSeemRobot", "Jesteś atakowany"}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_wrongData", "Błędne dane."}, 
                    } 
                }

            };
            ApplicationTranslationData = new Dictionary<string, Dictionary<string, string>>()
            {
                {"pl", new Dictionary<string, string> 
                    {
                        {"_wrongOperations", "Błędne działanie."}, 
                    } 
                }

            };
            
        }
    }
}
