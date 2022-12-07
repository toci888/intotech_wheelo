using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Models.TripCollocation;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Association.SourceDestinationCollocating;
using Intotech.Wheelo.Bll.Porsche.Interfaces.PersistenceAggregation;
using Microsoft.AspNetCore.Mvc;
using Toci.Driver.Database.Persistence.Models;

namespace Toci.Driver.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountCollocationController : ApiSimpleControllerBase<ICollocator<IWorkTripLogic, IAccountscollocationLogic>>
    {
        public AccountCollocationController(ICollocator<IWorkTripLogic, IAccountscollocationLogic> logic) : base(logic)
        {
        }

        [HttpPost("make-match")]
        public ReturnedResponse<TripCollocationDto> MakeMatch(int accountId, string searchId)
        {
            return Service.CollocateAndMatch(accountId, searchId);
        }
    }
}
