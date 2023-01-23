using Intotech.Common.Bll.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.Interfaces.Emails
{
    public interface IEmailSender
    {
        bool SendEmail(EmailContent content);
    }
}
