using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Models.TripCollocation;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Association;
using Microsoft.AspNetCore.Mvc;

namespace Toci.Driver.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssociationMapDataController : ApiSimpleControllerBase<IAssociationMapDataService>
    {
        public AssociationMapDataController(IAssociationMapDataService logic) : base(logic)
        {
        }

        [HttpGet("association-map-data")]
        public ReturnedResponse<TripCollocationDto> GetTripCollocation(int accountId)
        {
            return Service.GetTripCollocation(accountId);
        }
    }
}
