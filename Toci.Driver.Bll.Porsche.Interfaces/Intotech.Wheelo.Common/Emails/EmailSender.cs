using Intotech.Common.Bll;
using Intotech.Common.Bll.Interfaces;
using Intotech.Wheelo.Common.Interfaces.Emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.Emails
{
    public class EmailSender : IEmailSender
    {
        protected IEmailUtil EmailsSender = new EmailUtil(new EmailSettings()
        {
            AdminLoginAddress = "admin@intotech.com.pl",
            AdminPassword = "Toci123.",
            Port = 587,
            SmtpAddress = "mail.intotech.com.pl"
        });

        public virtual bool SendEmail(EmailContent content)
        {
            return EmailsSender.SendEmail(content);
        }
    }
}
