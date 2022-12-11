using Intotech.Wheelo.Bll.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Intotech.Wheelo.Bll.Models;
using Microsoft.IdentityModel.Tokens;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Common;
using System.Xml.Linq;
using Intotech.Wheelo.Bll.Models.Account;
using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Common;
using Intotech.Wheelo.Common.Interfaces;
using Intotech.Wheelo.Common.Logging;

namespace Intotech.Wheelo.Bll.Persistence
{
    public class AccountRoleLogic : Logic<Accountrole>, IAccountRoleLogic
    {
        private readonly AuthenticationSettings _authenticationSettings;
        protected Logic<Account> accountLogic = new Logic<Account>();

        public AccountRoleLogic(AuthenticationSettings authenticationSettings)
        {
            _authenticationSettings = authenticationSettings;
        }

        public ReturnedResponse<TokensModel> CreateNewAccessToken(string accessToken, string refreshToken)
        {
            ClaimsPrincipal clPr = GetPrincipalFromExpiredToken(accessToken);

            string email = clPr.Claims.Where(claim => claim.Type == ClaimTypes.NameIdentifier).First().Value;

            Account account = accountLogic.Select(m => m.Email == email).First();

            if (account == null)
            {
                ErrorHandler.LogDebug("Access token: " + accessToken + " and refresh token " + refreshToken + " CreateNewAccessToken call failed with account not found for the email " + email);

                return new ReturnedResponse<TokensModel>(null, I18nTranslation.Translation(I18nTags.AccountNotFound), false, ErrorCodes.AccountNotFound);
            }

            if (account.Refreshtoken != refreshToken)
            {
                ErrorHandler.LogDebug("Access token: " + accessToken + " and refresh token " + refreshToken + " CreateNewAccessToken call failed with invalid refresh token for the email " + email);

                return new ReturnedResponse<TokensModel>(null, I18nTranslation.Translation(I18nTags.ErrorPleaseLogInToApp), false, ErrorCodes.ErrorPleaseLogInToApp);
            }

            if (account.Refreshtokenvalid < DateTime.Now)
            {
                return new ReturnedResponse<TokensModel>(null, I18nTranslation.Translation(I18nTags.RefreshTokenExpiredPleaseLogIn), false, ErrorCodes.RefreshTokenExpiredPleaseLogIn);
            }

            TokensModel tokensModel = new TokensModel();

            tokensModel.AccessToken = GenerateJwt(new LoginDto() { Email = account.Email, Password = account.Password }).AccessToken;

            tokensModel.RefreshToken = account.Refreshtoken = StringUtils.GetRandomString(AccountLogicConstants.RefreshTokenMaxLength);

            accountLogic.Update(account);

            return new ReturnedResponse<TokensModel>(tokensModel, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        protected ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey)),
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        public AccountRoleDto GenerateJwt(LoginDto user)
        {
            Accountrole userRole = Select(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            AccountRoleDto u = DtoModelMapper.Map< AccountRoleDto , Accountrole>(userRole);

            if (u is null)
            {
                //throw new Exception("Invalid username or password");
                //throw new BadRequestException("Invalid username or password");
                return null;
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, u.Email),
                new Claim(ClaimTypes.Name, $"{u.Name} {u.Surname}"),
                new Claim(ClaimTypes.Role, $"{u.Rolename}"),
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            SigningCredentials cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            DateTime expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            JwtSecurityToken token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer, claims, expires: expires, signingCredentials: cred);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            u.AccessToken = tokenHandler.WriteToken(token);

            return u;
        }

        public int ResetPassword(int userId, string password)
        {
            Account user = accountLogic.Select(m => m.Id == userId).FirstOrDefault();

            user.Password = password;

            return accountLogic.Update(user).Id;
        }
    }
}
