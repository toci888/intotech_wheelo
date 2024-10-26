using Intotech.Common.Bll;
using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Models.Isfa;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
            var suggestions = VfriendSuggestionLogic.Select(m => m.Accountid == accountId).ToList();
            return new ReturnedResponse<List<Vfriendsuggestion>>(suggestions, I18nTranslationDep.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<List<Vfriendsuggestion>> SuggestedFriends(int accountId)
        {
            var suggestedFriends = VfriendSuggestionLogic.Select(m => m.Suggestedfriendid == accountId || m.Suggestedaccountid == accountId).ToList();
            return new ReturnedResponse<List<Vfriendsuggestion>>(suggestedFriends, I18nTranslationDep.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<List<Vfriendsuggestion>> MakeSuggestion(CreateFriendSuggestionDto dto)
        {
            if (dto.SuggestedAccountId > dto.SuggestedAccountFriendId)
            {
                // Swap IDs for consistency
                (dto.SuggestedAccountId, dto.SuggestedAccountFriendId) = (dto.SuggestedAccountFriendId, dto.SuggestedAccountId);
            }

            var existingSuggestion = FriendSuggestionLogic.Select(m => m.Idsuggested == dto.SuggestedAccountId && m.Idsuggestedfriend == dto.SuggestedAccountFriendId).FirstOrDefault();
            if (existingSuggestion == null)
            {
                FriendSuggestionLogic.Insert(new Friendsuggestion
                {
                    Idaccount = dto.SuggestingAccountId,
                    Idsuggested = dto.SuggestedAccountId,
                    Idsuggestedfriend = dto.SuggestedAccountFriendId
                });
            }

            var suggestions = VfriendSuggestionLogic.Select(m => m.Accountid == dto.SuggestingAccountId).ToList();
            return new ReturnedResponse<List<Vfriendsuggestion>>(suggestions, I18nTranslation.Translate(dto.Language, I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<Vfriendsuggestion> UpdateSuggestion(UpdateFriendSuggestionDto dto)
        {
            var suggestion = FriendSuggestionLogic.Select(m => m.Id == dto.Id).FirstOrDefault();
            if (suggestion == null)
            {
                return new ReturnedResponse<Vfriendsuggestion>(null, I18nTranslation.Translate("Suggestion not found", I18nTags.Error), false, ErrorCodes.NotFound);
            }

            // Update the suggestion with the new values
            suggestion.Idsuggested = dto.SuggestedAccountId;
            suggestion.Idsuggestedfriend = dto.SuggestedAccountFriendId;
            FriendSuggestionLogic.Update(suggestion);

            return new ReturnedResponse<Vfriendsuggestion>(suggestion, I18nTranslation.Translate("Suggestion updated successfully", I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<bool> DeleteSuggestion(DeleteFriendSuggestionDto dto)
        {
            var suggestion = FriendSuggestionLogic.Select(m => m.Id == dto.Id).FirstOrDefault();
            if (suggestion == null)
            {
                return new ReturnedResponse<bool>(false, I18nTranslation.Translate("Suggestion not found", I18nTags.Error), false, ErrorCodes.NotFound);
            }

            FriendSuggestionLogic.Delete(suggestion);
            return new ReturnedResponse<bool>(true, I18nTranslation.Translate("Suggestion deleted successfully", I18nTags.Success), true, ErrorCodes.Success);
        }
    }
}