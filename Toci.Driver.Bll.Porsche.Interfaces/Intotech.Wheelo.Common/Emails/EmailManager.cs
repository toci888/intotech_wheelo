using Intotech.Common.Bll.Interfaces;
using Intotech.Wheelo.Common.Interfaces.Emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.Emails
{
    public class EmailManager : IEmailManager
    {
        protected string LanguageCode;
        protected EmailSender EmailMsgSender = new EmailSender();
        public const string EmailFrom = "intotech.wheelo@gmail.com";

        public EmailManager(string languageCode) 
        {
            LanguageCode = languageCode;
        }

        protected Dictionary<string, Dictionary<string, Func<List<string>, string>>> MessagesLanguageMap = new Dictionary<string, Dictionary<string, Func<List<string>, string>>>()
        {
            { I18nTags.LanguageCodePl, new Dictionary<string, Func<List<string>, string>>()
                {
                    { I18nEmailMessagesTags.EmailVerificationCode, (data) => string.Format("Witaj {0}, Niniejszym przesyłamy kod potwierdzenia Twojego adresu email: {1}.", data[0], data[1]) }
                }
            },
            { I18nTags.LanguageCodeEn, new Dictionary<string, Func<List<string>, string>>()
                {
                    { I18nEmailMessagesTags.EmailVerificationCode, (data) => string.Format("Hello {0}, we hereby send you the email verification code: {1}.", data[0], data[1]) }
                }
            }
        };

        public virtual bool SendEmailVerificationCode(string emailTo, string userName, string verificationCode)
        {
            string message = MessagesLanguageMap[LanguageCode][I18nEmailMessagesTags.EmailVerificationCode](new List<string>() { userName, verificationCode });

            return EmailMsgSender.SendEmail(new EmailContent() { Body = message, EmailTo = emailTo, From = EmailFrom, Subject = I18nTranslation.Translation(I18nTags.PleaseConfirmYourWheeloAccountRegistration) });
        }
    }
}
