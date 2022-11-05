using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Toci.Common.Microservices;
using Toci.Driver.Database.Persistence.Models;

namespace Toci.Driver.Api.Controllers
{
    [ApiController]
    public class CarController : ApiControllerBase<ICarLogic, Car>
    {
        public CarController(ICarLogic logic) : base(logic)
        {
        }
    }
}
