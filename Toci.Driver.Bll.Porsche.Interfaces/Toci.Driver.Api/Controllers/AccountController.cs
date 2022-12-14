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
public class AccountController : ApiSimpleControllerBase<IWheeloAccountService>
{
    protected IGafManager GafManager;

    public AccountController(IWheeloAccountService service, IGafManager gafManager) : base(service) //IAccountRoleLogic logic, IAccountLogic accLogic
    {
        GafManager = gafManager;
    }


    [HttpPost("register")]
    public ReturnedResponse<AccountRegisterDto> Register(AccountRegisterDto sa)
    {
        ReturnedResponse<AccountRegisterDto> reg = Service.Register(sa);

        return reg;
    }

    [HttpPost("confirm-email")]
    public ReturnedResponse<AccountRoleDto> ConfirmEmail(EmailConfirmDto EcDto)
    {
        return Service.ConfirmEmail(EcDto);
    }

    [HttpPost("login")]
    public ReturnedResponse<AccountRoleDto> Login(LoginDto lDto)
    {
        ReturnedResponse<AccountRoleDto> sa = Service.Login(lDto);

        return sa;
    }

    [HttpGet("refresh-token")]
    public ReturnedResponse<TokensModel> CreateNewAccessToken(string accessToken, string refreshToken)
    {
        return Service.CreateNewAccessToken(accessToken, refreshToken);
    }

    [AllowAnonymous]
    [HttpPost("reset-password")]
    public ReturnedResponse<int> ResetPassword(int userId, string token, [FromBody] string password)
    {
        return Service.ResetPassword(userId, password, token);
    }

    [HttpPatch("$id/settings/theme-mode")]
    public ReturnedResponse<Accountmode> SetMode(int accountId, [FromBody] int themeMode)
    {
        return Service.SetMode(accountId, themeMode);
    }

    [HttpGet("$id/settings/theme-mode")]
    public ReturnedResponse<Accountmode> GetMode(int accountId)
    {
        return Service.GetMode(accountId);
    }

    [HttpGet("request-password-reset")]
    public ReturnedResponse<int> RequestPasswordReset(string email)
    {
        return Service.RequestPasswordReset(email);
    }

    [HttpGet("EnigmaticUrl")]
    public List<Account> GetAllUsers()
    {
        return Service.GetAllUsers();
    }
}