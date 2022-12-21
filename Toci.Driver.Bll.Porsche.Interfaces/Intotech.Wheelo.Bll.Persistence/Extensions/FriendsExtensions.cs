using Intotech.Wheelo.Bll.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Persistence.Extensions
{
    public static class FriendsExtensions
    {
        public static bool AreFriends(this IFriendLogic friendsLogic, int accountId, int potentialFriendAccountId)
        {
            int swap = accountId;

            if (accountId > potentialFriendAccountId)
            {
                accountId = potentialFriendAccountId;
                potentialFriendAccountId = swap;
            }

            return friendsLogic.Select(m => m.Idaccount == accountId && m.Idfriend == potentialFriendAccountId).Any();
        }
    }
}
