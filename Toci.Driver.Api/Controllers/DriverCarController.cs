using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Driver;
using Microsoft.AspNetCore.Mvc;
using Toci.Driver.Bll.Porsche.Interfaces.Services;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverCarController : ApiSimpleControllerBase<ICarService>
    {
        public DriverCarController(ICarService service) : base(service)
        {
        }

        [HttpGet("get-driver-car-info/{idAccount}")]
        public ReturnedResponse<Accountscarslocation> GetDriverCarInfo(int idAccount)
        {
            return null;//Service.g(idAccount);
        }

        [HttpPost("set-driver-car")]
        public ReturnedResponse<CarDto> SetDriverCar(CarDto carData)
        {
            return Service.AddCar(carData);
        }
    }
}
