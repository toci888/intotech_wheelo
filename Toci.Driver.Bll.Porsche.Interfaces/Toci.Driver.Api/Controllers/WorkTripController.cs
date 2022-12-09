using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Models;
using Intotech.Wheelo.Bll.Models.TripCollocation;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Association.SourceDestinationCollocating;
using Intotech.Wheelo.Bll.Porsche.Interfaces.WorkTripAssociating;
using Intotech.Wheelo.Common.Interfaces.Models;
using Microsoft.AspNetCore.Mvc;
using Toci.Driver.Database.Persistence.Models;

namespace Toci.Driver.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkTripController : ApiSimpleControllerBase<IWorkTripGenAssociationService>
    {
        public WorkTripController(IWorkTripGenAssociationService logic) : base(logic)
        {
        }

        [HttpPost("add-work-trip")]
        public ReturnedResponse<TripGenCollocationDto> AddWorkTrip([FromBody]WorkTripGenDto workTripGen)
        {
            return Service.SetWorkTripGetCollocations(workTripGen);
        }

        [HttpGet("collocated-account")]
        public ReturnedResponse<AccountCollocationDto> GetAccountDataForMarker(int sourceAccountId, int associatedAccountId)
        {
            return Service.GetAccountDataForMarker(sourceAccountId, associatedAccountId);
        }
        /*
        [HttpPost]
        [Route("add-work-trip")]
        public ReturnedResponse<TripCollocationDto> AddWorkTrip(WorktripDto wt)
        {
            wt.Fromhour = new TimeOnly(wt.IFromHour, wt.IFromMinute);
            wt.Tohour = new TimeOnly(wt.IToHour, wt.IToMinute);

            return Service.AddWorkTrip(wt);
        }

        [HttpGet]
        [Route("associated-users")]
        public ReturnedResponse<TripCollocationDto> GetAssociatedUsers(int accountId, string searchId)
        {
            return Service.GetUserAssociations(accountId, searchId);
        }
        */
    }
}
