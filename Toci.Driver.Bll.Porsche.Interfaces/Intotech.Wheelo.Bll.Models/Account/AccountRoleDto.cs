using Intotech.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.Account
{
    public class AccountRoleDto : Accountrole
    {

        public string FirstName { get { return Name; } }
        public string LastName { get { return Surname; } }
        //public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
    }
}
