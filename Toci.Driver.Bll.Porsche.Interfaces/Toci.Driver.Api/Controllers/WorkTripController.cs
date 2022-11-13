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
        public List<Vaccountscollocation> AddWorkTrip(WorktripDto wt)
        {
            wt.Fromhour = new TimeOnly(wt.IFromHour, wt.IFromMinute);
            wt.Tohour = new TimeOnly(wt.IToHour, wt.IToMinute);

            return Logic.AddWorkTrip(wt);
        }

        [HttpGet]
        [Route("associated-users")]
        public List<Vaccountscollocation> GetAssociatedUsers(int accountId)
        {
            return Logic.GetUserAssociations(accountId);
        }

    }
}
