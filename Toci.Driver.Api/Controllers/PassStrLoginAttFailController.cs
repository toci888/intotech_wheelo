using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Porsche.Interfaces.User;
using Microsoft.AspNetCore.Mvc;
using Toci.Driver.Database.Persistence.Models;

namespace Toci.Driver.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassStrLoginAttFailController : ApiSimpleControllerBase<IPassStrLoginAttFailService>
    {
        public PassStrLoginAttFailController(IPassStrLoginAttFailService service) : base(service)
        {
        }

        [HttpPost("login-attempt-fail")]
        public ReturnedResponse<Failedloginattempt> Julia(Failedloginattempt failedloginattempt) {
        
            return Service.SetFailedLoginAttempt(failedloginattempt);
        }
    }
}
