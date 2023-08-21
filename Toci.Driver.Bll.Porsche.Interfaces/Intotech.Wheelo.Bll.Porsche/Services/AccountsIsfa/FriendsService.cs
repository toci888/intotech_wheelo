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
using Intotech.Common.Bll;
using Intotech.Common.Interfaces;

namespace Intotech.Wheelo.Bll.Porsche.Services.AccountsIsfa
{
    public class FriendsService : ServiceBaseEx, IFriendsService
    {
        protected IVfriendLogic VfriendLogic;
        protected IFriendLogic FriendLogic;
        protected IAccountLogic AccountLogic;
        protected IAccountIsfaToDto<Vfriend, FriendsDto> AccountsMapper;

        public FriendsService(
            IVfriendLogic vfriendLogic,
            IFriendLogic friendLogic,
            IAccountIsfaToDto<Vfriend, FriendsDto> accountsMapper,
            IAccountLogic accountLogic,
            ITranslationEngineI18n i18nTranslation) : base(i18nTranslation)
        {
            VfriendLogic = vfriendLogic;
            FriendLogic = friendLogic;
            AccountsMapper = accountsMapper;
            AccountLogic = accountLogic;
        }

        public virtual ReturnedResponse<List<FriendsDto>> GetVfriends(int accountId)
        {
            List<Vfriend> friends = VfriendLogic.Select(m => m.Id == accountId || m.Friendidaccount == accountId).ToList();
            
            List<FriendsDto> frDto = AccountsMapper.Map(friends, accountId);

            return new ReturnedResponse<List<FriendsDto>>(frDto, I18nTranslationDep.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<List<FriendsDto>> SearchVfriends(int accountId, string query)
        {
            List<Vfriend> friends = VfriendLogic.Select(m => (m.Id == accountId || m.Friendidaccount == accountId) && 
                                                             (m.Friendname.Contains(query) || m.Friendsurname.Contains(query))).ToList();
            List<FriendsDto> frDto = AccountsMapper.Map(friends, accountId);

            return new ReturnedResponse<List<FriendsDto>>(frDto, I18nTranslationDep.Translation(I18nTags.Success), true, ErrorCodes.Success);
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
                return new ReturnedResponse<bool>(false, I18nTranslationDep.Translation(I18nTags.FriendshipNotFound), false, ErrorCodes.FriendshipNotFound);
            }

            return new ReturnedResponse<bool>(FriendLogic.Delete(fr) > 0, I18nTranslationDep.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<Vfriend> AddFriend(NewFriendAddDto entityDto)
        {
            entityDto = entityDto.RefreshSwapDto();

            Account acc1 = AccountLogic.Select(m => m.Id == entityDto.Idaccount).FirstOrDefault();

            if (acc1 != null)
            {
                Account acc2 = AccountLogic.Select(m => m.Id == entityDto.Idfriend).FirstOrDefault();

                if (acc2 != null)
                {
                    Friend testFr = FriendLogic
                        .Select(m => m.Idaccount == entityDto.Idaccount && m.Idfriend == entityDto.Idfriend).FirstOrDefault();

                    if (testFr == null)
                    {
                        FriendLogic.Insert(new Friend()
                            { Idaccount = entityDto.Idaccount, Idfriend = entityDto.Idfriend, Method = entityDto.Method });
                    }
                }
            }

            return new ReturnedResponse<Vfriend>(VfriendLogic.Select(m => m.Id == entityDto.Idaccount && m.Friendidaccount == entityDto.Idfriend).First(),
                I18nTranslation.Translate(DefaultLang, I18nTags.Success), true, ErrorCodes.Success);

        }
    }
}
