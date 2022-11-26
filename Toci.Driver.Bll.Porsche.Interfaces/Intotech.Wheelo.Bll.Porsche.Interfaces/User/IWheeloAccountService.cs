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
        ReturnedResponse<Simpleaccount> Register(Simpleaccount sAccount);

        ReturnedResponse<Simpleaccount> Login(LoginDto loginDto);

        //ReturnedResponse<Simpleaccount> Login(LoginDto loginDto);
    }
}
