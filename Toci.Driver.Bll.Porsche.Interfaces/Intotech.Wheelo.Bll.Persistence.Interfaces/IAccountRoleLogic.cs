using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Bll.Interfaces;
using Intotech.Wheelo.Bll.Models.Account;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Persistence.Interfaces;

public interface IAccountRoleLogic : ILogicBase<Accountrole>
{
    public AccountRoleDto GenerateJwt(LoginDto user);
    public int ResetPassword(int userId, string password);

    public ReturnedResponse<TokensModel> CreateNewAccessToken(string accessToken, string refreshToken);
}
