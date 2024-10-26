public interface IFriendsSuggestionsService
{
    ReturnedResponse<List<Vfriendsuggestion>> GetSuggestions(int accountId);
    ReturnedResponse<List<Vfriendsuggestion>> SuggestedFriends(int accountId);
    ReturnedResponse<List<Vfriendsuggestion>> MakeSuggestion(CreateFriendSuggestionDto dto);
    ReturnedResponse<Vfriendsuggestion> UpdateSuggestion(UpdateFriendSuggestionDto dto);
    ReturnedResponse<bool> DeleteSuggestion(DeleteFriendSuggestionDto dto);
}