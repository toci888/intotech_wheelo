using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.PersistenceAggregation;
using Microsoft.AspNetCore.Mvc;

namespace Toci.Driver.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountCollocationController : ApiSimpleControllerBase<IAccountCollocationMatch<IUsersLocationLogic, IUsersCollocationLogic>>
    {
        public AccountCollocationController(IAccountCollocationMatch<IUsersLocationLogic, IUsersCollocationLogic> logic) : base(logic)
        {
        }

        [HttpPost("make-match")]
        public bool MakeMatch(int idFirst, int idSecond)
        {
            return Logic.TryCollocate(idFirst, idSecond);
        }
    }
}
