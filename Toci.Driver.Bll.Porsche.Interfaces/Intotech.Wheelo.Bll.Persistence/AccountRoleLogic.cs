using Intotech.Wheelo.Bll.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Intotech.Wheelo.Bll.Models;
using Microsoft.IdentityModel.Tokens;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Common;
using System.Xml.Linq;
using Intotech.Wheelo.Bll.Models.Account;
using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Common;
using Intotech.Wheelo.Common.Interfaces;
using Intotech.Wheelo.Common.Logging;

namespace Intotech.Wheelo.Bll.Persistence
{
    public class AccountRoleLogic : Logic<Accountrole>, IAccountRoleLogic
    {
    }
}
