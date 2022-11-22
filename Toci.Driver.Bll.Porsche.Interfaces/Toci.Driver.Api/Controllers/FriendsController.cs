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
        [Route("get-friends")]
        public List<Vfriend> GetVfriends(int accountId)
        {
            return Logic.GetVfriends(accountId);
        }

        [HttpDelete]
        [Route("Unfriend")]
        public bool Unfriend(int accountId, int idFriendToRemove)
        {
            return Logic.Unfriend(accountId, idFriendToRemove);
        }
    }
}
