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
        protected IFriendLogic FriendLogic;

        public FriendsService(IVfriendLogic vfriendLogic, IFriendLogic friendLogic)
        {
            VfriendLogic = vfriendLogic;
            FriendLogic = friendLogic;
        }

        public List<Vfriend> GetVfriends(int accountId)
        {
            return VfriendLogic.Select(m => m.Accountid == accountId).ToList();
        }

        public virtual bool Unfriend(int accountId, int idFriendToRemove)
        {
            Friend fr = FriendLogic.Select(m => m.Idfriend == idFriendToRemove && m.Idaccount == accountId).First();

            return FriendLogic.Delete(fr) > 0;
        }
    }
}
