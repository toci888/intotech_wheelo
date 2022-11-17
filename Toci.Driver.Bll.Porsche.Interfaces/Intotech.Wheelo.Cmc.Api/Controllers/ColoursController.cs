using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Bentley.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Cmc.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColoursController : ApiSimpleControllerBase<IColourManager>
    {
        public ColoursController(IColourManager logic) : base(logic)
        {
        }

        [HttpGet]
        [Route("get-colours-for-wildcard")]
        public List<Colour> GetColoursForWildcard(string beginning)
        {
            return Logic.GetColoursForWildcard(beginning);
        }
    }
}
