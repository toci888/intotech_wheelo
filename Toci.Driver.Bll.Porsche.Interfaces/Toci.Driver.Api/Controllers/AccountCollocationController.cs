using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Association.SourceDestinationCollocating;
using Intotech.Wheelo.Bll.Porsche.Interfaces.PersistenceAggregation;
using Microsoft.AspNetCore.Mvc;
using Toci.Driver.Database.Persistence.Models;

namespace Toci.Driver.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountCollocationController : ApiSimpleControllerBase<ICollocator<IWorkTripLogic, IUsersCollocationLogic>>
    {
        public AccountCollocationController(ICollocator<IWorkTripLogic, IUsersCollocationLogic> logic) : base(logic)
        {
        }

        [HttpPost("make-match")]
        public ReturnedResponse<List<Vaccountscollocation>> MakeMatch(int accountId)
        {
            return Service.Collocate(accountId);
        }
    }
}
