using Intotech.Wheelo.Chat.Models.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Chat.Dodge.Interfaces
{
    public interface IAccountService
    {
        UserCacheDto GetAccount(string email);
    }
}
