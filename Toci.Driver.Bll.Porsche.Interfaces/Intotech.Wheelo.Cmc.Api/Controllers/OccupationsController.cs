using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Bentley.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Cmc.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OccupationsController : ApiSimpleControllerBase<IOccupationsService>
    {
        public OccupationsController(IOccupationsService logic) : base(logic)
        {
        }

        [HttpGet]
        [Route("get-occupation-for-wildcard")]
        public List<Occupation> GetOccupationsForContain(string contain)
        {
            return Logic.GetOccupationsForContain(contain);
        }
    }
}
