using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.Interfaces.User
{
    public interface IWheeloAccountService
    {
        ReturnedResponse<AccountRoleDto> Register(AccountRegisterDto sAccount);

        ReturnedResponse<AccountRoleDto> Login(LoginDto loginDto);

        ReturnedResponse<AccountRoleDto> ConfirmEmail(EmailConfirmDto EcDto);

        ReturnedResponse<Accountmode> GetMode(int accountId);

        ReturnedResponse<Accountmode> SetMode(int accountId, int mode);

        ReturnedResponse<bool> SetAllowsNotifications(int accountId, bool allowsNotifications);

        ReturnedResponse<int> ResetPassword(string email, string password, string token);

        ReturnedResponse<TokensModel> CreateNewAccessToken(string accessToken, string refreshToken);

        ReturnedResponse<int> RequestPasswordReset(string email);

        List<Account> GetAllUsers(); // temporary, development purpose, TODO REMOVE
    }
}
