using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Models;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Association.SourceDestinationCollocating;
using Microsoft.AspNetCore.Mvc;
using Toci.Driver.Database.Persistence.Models;

namespace Toci.Driver.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkTripController : ApiSimpleControllerBase<ICollocator<IWorkTripLogic, IUsersCollocationLogic>>
    {
        public WorkTripController(ICollocator<IWorkTripLogic, IUsersCollocationLogic> logic) : base(logic)
        {
        }

        [HttpPost]
        [Route("add-work-trip")]
        public ReturnedResponse<List<Vaccountscollocation>> AddWorkTrip(WorktripDto wt)
        {
            wt.Fromhour = new TimeOnly(wt.IFromHour, wt.IFromMinute);
            wt.Tohour = new TimeOnly(wt.IToHour, wt.IToMinute);

            return Service.AddWorkTrip(wt);
        }

        [HttpGet]
        [Route("associated-users")]
        public ReturnedResponse<List<Vaccountscollocation>> GetAssociatedUsers(int accountId)
        {
            return Service.GetUserAssociations(accountId);
        }

    }
}
