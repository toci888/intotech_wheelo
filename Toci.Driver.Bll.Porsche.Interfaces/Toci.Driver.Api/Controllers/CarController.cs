﻿using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Toci.Driver.Database.Persistence.Models;

namespace Toci.Driver.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarController : ApiSimpleControllerBase<ICarLogic> // todo fix this when coding, ICarService..
{
    public CarController(ICarLogic logic) : base(logic)
    {
    }
}
