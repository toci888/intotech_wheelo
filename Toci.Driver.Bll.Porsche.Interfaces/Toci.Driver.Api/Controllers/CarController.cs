using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Toci.Driver.Database.Persistence.Models;

namespace Toci.Driver.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarController : ApiControllerBase<ICarLogic, Car>
{
    public CarController(ICarLogic logic) : base(logic)
    {
    }
}
