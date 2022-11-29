using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Services.AccountsIsfa;
using Intotech.Wheelo.Common;
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
            return new ReturnedResponse<List<Vfriend>>(VfriendLogic.Select(m => m.Accountid == accountId).ToList(), "", true);
        }

        public virtual ReturnedResponse<bool> Unfriend(int accountId, int idFriendToRemove)
        {
            Friend fr = FriendLogic.Select(m => m.Idfriend == idFriendToRemove && m.Idaccount == accountId).FirstOrDefault();

            if (fr == null)
            {
                return new ReturnedResponse<bool>(false, I18nTranslation.Translation(I18nTags.FriendshipNotFound), false);
            }

            return new ReturnedResponse<bool>(FriendLogic.Delete(fr) > 0, I18nTranslation.Translation(I18nTags.Success), true);
        }
    }
}
