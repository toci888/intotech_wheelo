using Intotech.Wheelo.Bll.Models;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Intotech.Common.Microservices;
using Toci.Driver.Dal.Invitation.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Toci.Driver.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ApiControllerBase<IAccountLogic, Accountrole>
{
    public AccountController(IAccountLogic logic) : base(logic)
    {
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public Accountrole RegisterUser([FromBody] AccountRegisterDto user)
    {
        return Logic.CreateAccount(user);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public ActionResult<Account> Login([FromBody] LoginDto user)
    {
        Accountrole loggedUser = Logic.GenerateJwt(user);
        return Ok(loggedUser);
    }

    [AllowAnonymous]
    [HttpPost("reset-password")]
    public int ResetPassword(int userId, [FromBody] string password)
    {
        return Logic.ResetPassword(userId, password);
    }
}