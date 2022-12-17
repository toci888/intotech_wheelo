using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Models.Isfa;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Services.AccountsIsfa;
using Intotech.Wheelo.Common;
using Intotech.Wheelo.Common.Interfaces;
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

        public virtual ReturnedResponse<List<Vfriend>> GetVfriends(int accountId)
        {
            return new ReturnedResponse<List<Vfriend>>(VfriendLogic.Select(m => m.Accountid == accountId || m.Friendaccountid == accountId).ToList(), I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<bool> Unfriend(int accountId, int idFriendToRemove)
        {
            Friend fr = FriendLogic.Select(m => m.Idfriend == idFriendToRemove && m.Idaccount == accountId).FirstOrDefault();

            if (fr == null)
            {
                return new ReturnedResponse<bool>(false, I18nTranslation.Translation(I18nTags.FriendshipNotFound), false, ErrorCodes.FriendshipNotFound);
            }

            return new ReturnedResponse<bool>(FriendLogic.Delete(fr) > 0, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<Vfriend> AddFriend(NewFriendAddDto friend)
        {
            friend = friend.RefreshDto();

            Friend testFr = FriendLogic.Select(m => m.Idaccount == friend.Idaccount && m.Idfriend == friend.Idfriend).FirstOrDefault();

            if (testFr == null)
            {
                FriendLogic.Insert(new Friend() { Idaccount = friend.Idaccount, Idfriend = friend.Idfriend, Method = friend.Method });
            }

            return new ReturnedResponse<Vfriend>(VfriendLogic.Select(m => m.Accountid == friend.Idaccount && m.Friendaccountid == friend.Idfriend).First(),
                I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);

        }
    }
}
