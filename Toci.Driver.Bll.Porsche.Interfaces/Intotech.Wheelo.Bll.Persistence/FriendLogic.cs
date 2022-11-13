using Intotech.Wheelo.Bll.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Persistence
{
    public class FriendLogic : Logic<Friend>, IFriendLogic
    {
        // powielenie di z invitation i stworzenie Vfriend
        protected IVfriendLogic VFriendLogic;

        public FriendLogic(IVfriendLogic iVfriendLogic)
        {
            VFriendLogic = iVfriendLogic;
        }

        public virtual Vfriend AccecptInviteToFriends(int proposalAccountId, int proposedAccountId)
        {
            Insert(new Friend() { Idfriend = proposalAccountId, Idaccount = proposedAccountId });

            return VFriendLogic.Select(m => m.Accountid == proposedAccountId).FirstOrDefault();            
        }
    }
}
