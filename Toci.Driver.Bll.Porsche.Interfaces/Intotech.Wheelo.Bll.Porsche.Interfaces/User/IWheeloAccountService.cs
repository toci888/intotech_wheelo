using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.Interfaces.User
{
    public interface IWheeloAccountService
    {
        ReturnedResponse<Account> Register(AccountRegisterDto sAccount);

        ReturnedResponse<Accountrole> Login(LoginDto loginDto);
    }
}
