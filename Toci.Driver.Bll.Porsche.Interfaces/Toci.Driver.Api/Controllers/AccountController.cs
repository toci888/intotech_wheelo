using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Intotech.Common.Microservices;
using Toci.Driver.Dal.Invitation.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Porsche.Interfaces;
using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Porsche.Interfaces.User;
using Intotech.Wheelo.Bll.Models.Account;

namespace Toci.Driver.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ApiSimpleControllerBase<IAccountRoleLogic>
{
    protected IGafManager GafManager;
    protected IWheeloAccountService WheeloAccountService;

    public AccountController(IAccountRoleLogic logic, IGafManager gafManager, IWheeloAccountService was) : base(logic)
    {
        GafManager = gafManager;
        WheeloAccountService = was;
    }

    
    [HttpPost("register")]
    public ActionResult<AccountRegisterDto> SimpleRegister(AccountRegisterDto sa)
    {
        ReturnedResponse<AccountRegisterDto>  reg = WheeloAccountService.Register(sa);

        if (!reg.IsSuccess)
        {
            return BadRequest(reg);
        }

        return sa;
    }

    [HttpPost("confirm-email")]
    public ReturnedResponse<AccountRoleDto> ConfirmEmail(EmailConfirmDto EcDto)
    {
        return WheeloAccountService.ConfirmEmail(EcDto);
    }

    [HttpPost("login")]
    public ActionResult<AccountRoleDto> Login(LoginDto lDto)
    {
        ReturnedResponse<AccountRoleDto> sa = WheeloAccountService.Login(lDto);

        if (!sa.IsSuccess)
        {
            return NotFound(sa);
        }

        return sa.MethodResult;
    }

    [HttpGet("refresh-token")]
    public ReturnedResponse<TokensModel> CreateNewAccessToken(string accessToken, string refreshToken)
    {
        return Service.CreateNewAccessToken(accessToken, refreshToken);
    }


   /* [AllowAnonymous]
    [HttpPost("register")]
    public Accountrole RegisterUser([FromBody] AccountRegisterDto user)
    {
        //if (user.Method == "wheelo")
        {
            return Logic.CreateAccount(user);
        }

        //return GafManager.RegisterByMethod(user.Method, "");
    }
   */
    /* [AllowAnonymous]
     [HttpPost("login")]
     public ActionResult<Account> Login([FromBody] LoginDto user)
     {
         Accountrole loggedUser = Logic.GenerateJwt(user);
         return Ok(loggedUser);
     }*/

    [AllowAnonymous]
    [HttpPost("reset-password")]
    public int ResetPassword(int userId, [FromBody] string password)
    {
        return Service.ResetPassword(userId, password);
    }

    [HttpPatch("$id/settings/theme-mode")]
    public ReturnedResponse<Accountmode> SetMode(int accountId, [FromBody] int themeMode)
    {
        return WheeloAccountService.SetMode(accountId, themeMode);
    }

    [HttpGet("$id/settings/theme-mode")]
    public ReturnedResponse<Accountmode> GetMode(int accountId)
    {
        return WheeloAccountService.GetMode(accountId);
    }
}