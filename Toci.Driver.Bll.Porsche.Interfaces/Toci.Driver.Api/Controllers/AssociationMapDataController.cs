using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Models.TripCollocation;
using Intotech.Wheelo.Bll.Persistence.Interfaces.SubServices;
using Microsoft.AspNetCore.Mvc;

namespace Toci.Driver.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssociationMapDataController : ApiSimpleControllerBase<IAssociationMapDataSubService>
    {
        public AssociationMapDataController(IAssociationMapDataSubService logic) : base(logic)
        {
        }

        [HttpGet("association-map-data")]
        public ReturnedResponse<TripCollocationDto> GetTripCollocation(int accountId, string searchId)
        {
            return Service.GetTripCollocation(accountId, searchId);
        }
    }
}
