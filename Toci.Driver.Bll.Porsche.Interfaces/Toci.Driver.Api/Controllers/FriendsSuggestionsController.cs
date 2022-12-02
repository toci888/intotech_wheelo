using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Models.Isfa;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Services.AccountsIsfa;
using Microsoft.AspNetCore.Mvc;
using Toci.Driver.Database.Persistence.Models;

namespace Toci.Driver.Api.Controllers
{
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
        public ReturnedResponse<List<Vfriendsuggestion>> MakeFriendSuggestion(MakeFriendSuggestionDto dto)
        {
            return Service.MakeSuggestion(dto);
        }
    }
}
