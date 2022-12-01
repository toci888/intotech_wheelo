using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.Interfaces.Emails
{
    public interface IEmailManager
    {
        bool SendEmailVerificationCode(string emailTo, string userName, string verificationCode);
    }
}
