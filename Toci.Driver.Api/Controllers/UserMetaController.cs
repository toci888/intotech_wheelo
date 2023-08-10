using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Models.OldModels;
using Intotech.Wheelo.Bll.Porsche.Interfaces.User;
using Microsoft.AspNetCore.Mvc;

namespace Toci.Driver.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserMetaController : ApiSimpleControllerBase<IUserMetaService>
    {
        public UserMetaController(IUserMetaService service) : base(service)
        {
        }

        [HttpPost("occupation-smoker")]
        public ReturnedResponse<SmokerOccupationDto> SetSmokerOccupation(SmokerOccupationDto smokerOccupationDto)
        {
            return Service.SetSmokerOccupation(smokerOccupationDto);
        }
    }
}
