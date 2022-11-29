using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Services.AccountsIsfa;
using Microsoft.AspNetCore.Mvc;
using Toci.Driver.Database.Persistence.Models;

namespace Toci.Driver.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ApiSimpleControllerBase<IFriendsService>
    {
        public FriendsController(IFriendsService logic) : base(logic)
        {
        }

        [HttpGet]
        [Route("your-friends")]
        public ReturnedResponse<List<Vfriend>> GetVfriends(int accountId)
        {
            return Service.GetVfriends(accountId);
        }

        [HttpDelete]
        [Route("unfriend")]
        public ReturnedResponse<bool> Unfriend(int accountId, int idFriendToRemove)
        {
            return Service.Unfriend(accountId, idFriendToRemove);
        }
    }
}
