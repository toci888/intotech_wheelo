using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Services.AccountsIsfa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.Services.AccountsIsfa
{
    public class FriendsService : IFriendsService
    {
        protected IVfriendLogic VfriendLogic;

        public FriendsService(IVfriendLogic vfriendLogic)
        {
            VfriendLogic = vfriendLogic;
        }

        public List<Vfriend> GetVfriends(int accountId)
        {
            return VfriendLogic.Select(m => m.Accountid == accountId).ToList();
        }
    }
}
