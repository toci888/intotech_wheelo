[Route("api/[controller]")]
[ApiController]
public class FriendsSuggestionsController : ApiSimpleControllerBase<IFriendsSuggestionsService>
{
    public FriendsSuggestionsController(IFriendsSuggestionsService logic) : base(logic)
    {
    }

    [HttpGet]
    [Route("friends-suggestions")]
    public ReturnedResponse<List<Vfriendsuggestion>> GetSuggestions(int accountId)
    {
        return Service.GetSuggestions(accountId);
    }

    [HttpGet("suggested-friends")]
    public ReturnedResponse<List<Vfriendsuggestion>> SuggestedFriends(int accountId)
    {
        return Service.SuggestedFriends(accountId);
    }

    [HttpPost("friend-suggestion")]
    public ReturnedResponse<List<Vfriendsuggestion>> MakeFriendSuggestion(CreateFriendSuggestionDto dto)
    {
        return Service.MakeSuggestion(dto);
    }

    [HttpPut("friend-suggestion")]
    public ReturnedResponse<Vfriendsuggestion> UpdateFriendSuggestion(UpdateFriendSuggestionDto dto)
    {
        return Service.UpdateSuggestion(dto);
    }

    [HttpDelete("friend-suggestion")]
    public ReturnedResponse<bool> DeleteFriendSuggestion(DeleteFriendSuggestionDto dto)
    {
        return Service.DeleteSuggestion(dto);
    }
}