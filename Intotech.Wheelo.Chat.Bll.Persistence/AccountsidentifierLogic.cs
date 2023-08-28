using Intotech.Wheelo.Chat.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Chat.Bll.Persistence
{
    public class AccountsidentifierLogic : Logic<Accountsidentifier>, IAccountsindentifierLogic
    {
        public AccountsidentifierLogic(bool cs) : base(cs)
        {
        }
    }
}
