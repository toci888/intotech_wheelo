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
        ReturnedResponse<AccountRegisterDto> Register(AccountRegisterDto sAccount);

        ReturnedResponse<AccountRoleDto> Login(LoginDto loginDto);

        ReturnedResponse<AccountRoleDto> ConfirmEmail(EmailConfirmDto EcDto);

        ReturnedResponse<Accountmode> GetMode(int accountId);

        ReturnedResponse<Accountmode> SetMode(int accountId, int mode);

      //  protected AccountRoleDto GenerateJwt(LoginDto user);

        ReturnedResponse<int> ResetPassword(int userId, string password, string token);

        ReturnedResponse<TokensModel> CreateNewAccessToken(string accessToken, string refreshToken);

        List<Account> GetAllUsers(); // temporary, development purpose, TODO REMOVE
    }
}
