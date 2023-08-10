using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Intotech.Common.Microservices;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Porsche.Interfaces;
using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Porsche.Interfaces.User;
using Intotech.Wheelo.Bll.Models.Tiny;
using Intotech.Wheelo.Common.Interfaces;
using Intotech.Wheelo.Common;
using Intotech.Wheelo.Bll.Models.OldModels;

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
        if (lDto.Method == "facebook" || lDto.Method == "google")
        {
            Accountrole result = GafManager.RegisterByMethod(lDto.Method, lDto.Token);

            if (result == null)
            {
                return new ReturnedResponse<AccountRoleDto>(null, I18nTranslation.Translation(I18nTags.WrongData), false, ErrorCodes.DataIntegrityViolated);
            }

            return Service.GafLogin(result);
        }

        ReturnedResponse<AccountRoleDto> sa = Service.Login(lDto);

        return sa;
    }

    [HttpPost("refresh-token")]
    public ReturnedResponse<TokensModel> CreateNewAccessToken([FromBody]TokensModel tokensModel)
    {
        return Service.CreateNewAccessToken(tokensModel.AccessToken, tokensModel.RefreshToken);
    }

    [AllowAnonymous]
    [HttpPost("reset-password")]
    public ReturnedResponse<int?> ResetPassword(ResetPasswordDto dto)
    {
        return Service.ResetPassword(dto.email, dto.password, dto.token);
    }

    [HttpPost("forgot-password-check-code")]
    public ReturnedResponse<int?> ResetPasswordCheckCode(EmailTokenDto emailToken)
    {
        return Service.ResetPasswordCheckCode(emailToken.email, emailToken.token);
    }

    [HttpPatch("{accountId}/settings/theme-mode")]
    public ReturnedResponse<bool> SetMode(int accountId, bool themeMode)
    {
        return Service.SetMode(accountId, themeMode);
    }

    [HttpPatch("{idAccount}/settings/notifications")]
    public ReturnedResponse<bool> SetAllowsNotifications(int idAccount, [FromBody] NotificationsModel allowsNotifications)
    {
        return Service.SetAllowsNotifications(idAccount, allowsNotifications.AreNotificationsEnabled);
    }

    [HttpGet("{accountId}/settings/theme-mode")]
    public ReturnedResponse<bool> GetMode(int accountId)
    {
        return Service.GetMode(accountId);
    }

    [HttpPost("forgot-password")]
    public ReturnedResponse<int?> ForgotPassword([FromBody] EmailDto email)
    {
        return Service.ForgotPassword(email.email);
    }

    [HttpPatch("{idAccount}/pushtoken")]
    public ReturnedResponse<PushTokenDto> SetPushToken(int idAccount, [FromBody]PushTokenDto pushToken)
    {
        return Service.SetPushToken(idAccount, pushToken);
    }

    [HttpPost("resend-email-verification-code")]
    public ReturnedResponse<bool> ResendEmailVerificationCode([FromBody] EmailDto email)
    {
        return Service.ResendEmailVerificationCode(email.email);
    }

    [HttpGet("EnigmaticUrl")]
    public List<Account> GetAllUsers()
    {
        return Service.GetAllUsers();
    }

    [HttpGet("EnigmaticUrlAuthorized")]
    [Authorize(Roles = "User")]
    public List<Account> GetAllUsersAuth()
    {
        return Service.GetAllUsers();
    }
}