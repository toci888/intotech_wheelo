using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Models.TripCollocation;
using Intotech.Wheelo.Bll.Persistence.Interfaces.SubServices;
using Intotech.Wheelo.Common.Interfaces.Models;
using Microsoft.AspNetCore.Mvc;
using Toci.Driver.Database.Persistence.Models;

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
        public ReturnedResponse<TripCollocationDto> GetTripCollocation(int accountId)
        {
            return Service.GetTripCollocation(accountId, "");
        }

        [HttpGet("association-user/{idAccount}")]
        public ReturnedResponse<AccountCollocationDto> GetCollocationUser(int idAccount)
        {
            return Service.GetCollocationUser(idAccount);
        }
    }
}
