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
    public ReturnedResponse<AccountRoleDto> Register(AccountRegisterDto sa)
    {
        ReturnedResponse<AccountRoleDto> reg = Service.Register(sa);

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
    public ReturnedResponse<int> ResetPassword(string email, string token, [FromBody] string password)
    {
        return Service.ResetPassword(email, password, token);
    }

    [HttpPatch("$accountId/settings/theme-mode")]
    public ReturnedResponse<bool> SetMode(int accountId, bool themeMode)
    {
        return Service.SetMode(accountId, themeMode);
    }

    [HttpPatch("$idAccount/settings/notifications")]
    public ReturnedResponse<bool> SetAllowsNotifications(int idAccount, [FromBody] bool allowsNotifications)
    {
        return Service.SetAllowsNotifications(idAccount, allowsNotifications);
    }

    [HttpGet("$accountId/settings/theme-mode")]
    public ReturnedResponse<bool> GetMode(int accountId)
    {
        return Service.GetMode(accountId);
    }

    [HttpGet("request-password-reset")]
    public ReturnedResponse<int> RequestPasswordReset(string email)
    {
        return Service.RequestPasswordReset(email);
    }

    [HttpPatch("{idAccount}/pushtoken")]
    public ReturnedResponse<PushTokenDto> SetPushToken(int idAccount, [FromBody]PushTokenDto pushToken)
    {
        return Service.SetPushToken(idAccount, pushToken);
    }

    [HttpGet("EnigmaticUrl")]
    public List<Account> GetAllUsers()
    {
        return Service.GetAllUsers();
    }
}