using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Bll.Interfaces;
using Intotech.Wheelo.Bll.Models.OldModels;
using Intotech.Wheelo.Bll.Models.Tiny;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.Interfaces.User
{
    public interface IWheeloAccountService : IService
    {
        ReturnedResponse<AccountRoleDto> Register(AccountRegisterDto sAccount);

        ReturnedResponse<AccountRoleDto> GafLogin(Accountrole accountrole);

        ReturnedResponse<AccountRoleDto> Login(LoginDto loginDto);

        ReturnedResponse<AccountRoleDto> ConfirmEmail(EmailConfirmDto EcDto);

        ReturnedResponse<bool> GetMode(int accountId);

        ReturnedResponse<bool> SetMode(int accountId, bool mode);

        ReturnedResponse<bool> SetAllowsNotifications(int accountId, bool allowsNotifications);

        ReturnedResponse<int?> ResetPasswordCheckCode(EmailTokenDto emailToken);

        ReturnedResponse<int?> ResetPassword(ResetPasswordDto dto);

        ReturnedResponse<TokensModel> CreateNewAccessToken(TokensModel tokensModel);

        ReturnedResponse<int?> ForgotPassword(EmailDto email);

        ReturnedResponse<PushTokenDto> SetPushToken(int idAccount, PushTokenDto pushToken);

        ReturnedResponse<bool> ResendEmailVerificationCode(EmailDto email);

        List<Account> GetAllUsers(); // temporary, development purpose, TODO REMOVE
    }
}
