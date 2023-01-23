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
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Intotech.Wheelo.Common.Interfaces.Models;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Persistence;

namespace Intotech.Wheelo.Bll.Porsche.Services.AccountsIsfa
{
    public class FriendsService : IFriendsService
    {
        protected IVfriendLogic VfriendLogic;
        protected IFriendLogic FriendLogic;
        protected IAccountLogic AccountLogic;
        protected IAccountIsfaToDto<Vfriend, FriendsDto> AccountsMapper;

        public FriendsService(IVfriendLogic vfriendLogic, IFriendLogic friendLogic, IAccountIsfaToDto<Vfriend, FriendsDto> accountsMapper, IAccountLogic accountLogic)
        {
            VfriendLogic = vfriendLogic;
            FriendLogic = friendLogic;
            AccountsMapper = accountsMapper;
            AccountLogic = accountLogic;
        }

        public virtual ReturnedResponse<List<FriendsDto>> GetVfriends(int accountId)
        {
            List<Vfriend> friends = VfriendLogic.Select(m => m.Idaccount == accountId || m.Friendidaccount == accountId).ToList();
            
            List<FriendsDto> frDto = AccountsMapper.Map(friends, accountId);

            return new ReturnedResponse<List<FriendsDto>>(frDto, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<bool> Unfriend(int accountId, int idFriendToRemove)
        {
            if (accountId > idFriendToRemove)
            {
                int swap = accountId;
                accountId = idFriendToRemove;
                idFriendToRemove = swap;
            }

            Friend fr = FriendLogic.Select(m => m.Idfriend == idFriendToRemove && m.Idaccount == accountId).FirstOrDefault();

            if (fr == null)
            {
                return new ReturnedResponse<bool>(false, I18nTranslation.Translation(I18nTags.FriendshipNotFound), false, ErrorCodes.FriendshipNotFound);
            }

            return new ReturnedResponse<bool>(FriendLogic.Delete(fr) > 0, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<Vfriend> AddFriend(NewFriendAddDto friend)
        {
            friend = friend.RefreshSwapDto();

            Account acc1 = AccountLogic.Select(m => m.Id == friend.Idaccount).FirstOrDefault();

            if (acc1 != null)
            {
                Account acc2 = AccountLogic.Select(m => m.Id == friend.Idfriend).FirstOrDefault();

                if (acc2 != null)
                {
                    Friend testFr = FriendLogic
                        .Select(m => m.Idaccount == friend.Idaccount && m.Idfriend == friend.Idfriend).FirstOrDefault();

                    if (testFr == null)
                    {
                        FriendLogic.Insert(new Friend()
                            { Idaccount = friend.Idaccount, Idfriend = friend.Idfriend, Method = friend.Method });
                    }
                }
            }

            return new ReturnedResponse<Vfriend>(VfriendLogic.Select(m => m.Idaccount == friend.Idaccount && m.Friendidaccount == friend.Idfriend).First(),
                I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);

        }
    }
}
