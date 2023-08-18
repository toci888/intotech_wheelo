using Intotech.Common.Bll;
using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Interfaces;
using Intotech.Wheelo.Bll.Models.Isfa;
using Intotech.Wheelo.Bll.Persistence;
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
    public class FriendsSuggestionsService : ServiceBaseEx, IFriendsSuggestionsService
    {
        protected IVfriendsuggestionLogic VfriendSuggestionLogic;
        protected IFriendsuggestionLogic FriendSuggestionLogic;

        public FriendsSuggestionsService(
            IVfriendsuggestionLogic vfriendSuggestionLogic,
            IFriendsuggestionLogic friendSuggestionLogic,
            ITranslationEngineI18n i18nTranslation) : base(i18nTranslation)
        {
            VfriendSuggestionLogic = vfriendSuggestionLogic;
            FriendSuggestionLogic = friendSuggestionLogic;
        }

        public virtual ReturnedResponse<List<Vfriendsuggestion>> GetSuggestions(int accountId)
        {
            return new ReturnedResponse<List<Vfriendsuggestion>>(VfriendSuggestionLogic.Select(m => m.Accountid == accountId).ToList(), I18nTranslationDep.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<List<Vfriendsuggestion>> MakeSuggestion(MakeFriendSuggestionDto entityDto)
        {
            if(entityDto.SuggestedAccountId > entityDto.SuggestedAccountFriendId) 
            {
                int swap = entityDto.SuggestedAccountId;
                entityDto.SuggestedAccountId = entityDto.SuggestedAccountFriendId;
                entityDto.SuggestedAccountFriendId = swap;
            }
            Friendsuggestion friendsuggestion = FriendSuggestionLogic.Select(m => m.Idsuggested == entityDto.SuggestedAccountId && m.Idsuggestedfriend == entityDto.SuggestedAccountFriendId).FirstOrDefault();
            
            if(friendsuggestion == null)
            {
                FriendSuggestionLogic.Insert(new Friendsuggestion() { Idaccount = entityDto.SuggestingAccountId, Idsuggested = entityDto.SuggestedAccountId, Idsuggestedfriend = entityDto.SuggestedAccountFriendId });
            }


            return new ReturnedResponse<List<Vfriendsuggestion>>(VfriendSuggestionLogic.Select(m => m.Accountid == entityDto.SuggestingAccountId).ToList(), I18nTranslation.Translate(entityDto.Language, I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<List<Vfriendsuggestion>> SuggestedFriends(int accountId)
        {
            return new ReturnedResponse<List<Vfriendsuggestion>>(VfriendSuggestionLogic.Select(m => m.Suggestedfriendid == accountId || m.Suggestedaccountid == accountId).ToList(), 
                I18nTranslationDep.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }
    }
}
