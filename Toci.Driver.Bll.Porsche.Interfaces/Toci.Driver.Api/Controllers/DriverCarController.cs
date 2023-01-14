using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Models;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Driver;
using Microsoft.AspNetCore.Mvc;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverCarController : ApiSimpleControllerBase<IDriverCarService>
    {
        public DriverCarController(IDriverCarService service) : base(service)
        {
        }

        [HttpGet("get-driver-car-info/{idAccount}")]
        public ReturnedResponse<Accountscarslocation> GetDriverCarInfo(int idAccount)
        {
            return Service.GetDriverCarInfo(idAccount);
        }

        [HttpPost("set-driver-car")]
        public ReturnedResponse<bool> SetDriverCar(CarDto carData)
        {
            return Service.SetDriverCar(carData);
        }
    }
}
