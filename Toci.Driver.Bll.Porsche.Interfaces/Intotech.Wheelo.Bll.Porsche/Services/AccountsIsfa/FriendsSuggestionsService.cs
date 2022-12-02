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
    public class FriendsSuggestionsService : IFriendsSuggestionsService
    {
        protected IVfriendSuggestionLogic VfriendSuggestionLogic;
        protected IFriendSuggestionLogic FriendSuggestionLogic;

        public FriendsSuggestionsService(IVfriendSuggestionLogic vfriendSuggestionLogic, IFriendSuggestionLogic friendSuggestionLogic)
        {
            VfriendSuggestionLogic = vfriendSuggestionLogic;
            FriendSuggestionLogic = friendSuggestionLogic;
        }

        public virtual ReturnedResponse<List<Vfriendsuggestion>> GetSuggestions(int accountId)
        {
            return new ReturnedResponse<List<Vfriendsuggestion>>(VfriendSuggestionLogic.Select(m => m.Accountid == accountId).ToList(), I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<List<Vfriendsuggestion>> MakeSuggestion(MakeFriendSuggestionDto friendSuggestionDto)
        {
            FriendSuggestionLogic.Insert(new Friendsuggestion() { Idaccount = friendSuggestionDto.SuggestingAccountId, Idsuggested = friendSuggestionDto.SuggestedAccountId, Idsuggestedfriend = friendSuggestionDto.SuggestedAccountFriendId });

            return new ReturnedResponse<List<Vfriendsuggestion>>(VfriendSuggestionLogic.Select(m => m.Accountid == friendSuggestionDto.SuggestingAccountId).ToList(), I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<List<Vfriendsuggestion>> SuggestedFriends(int accountId)
        {
            return new ReturnedResponse<List<Vfriendsuggestion>>(VfriendSuggestionLogic.Select(m => m.Suggestedfriendid == accountId || m.Suggestedaccountid == accountId).ToList(), 
                I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }
    }
}
