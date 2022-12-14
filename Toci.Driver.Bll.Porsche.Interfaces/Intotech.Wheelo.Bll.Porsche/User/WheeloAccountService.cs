﻿using Intotech.Common;
using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Models.Account;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.User;
using Intotech.Wheelo.Common;
using Intotech.Wheelo.Common.Interfaces;
using Intotech.Wheelo.Common.Interfaces.Emails;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Common.Emails;
using Intotech.Wheelo.Bll.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Intotech.Wheelo.Common.Logging;
using System.Security.Principal;

namespace Intotech.Wheelo.Bll.Porsche.User
{
    public class WheeloAccountService : IWheeloAccountService
    {
        private readonly AuthenticationSettings _authenticationSettings;
        protected IAccountLogic AccLogic;
        protected IAccountRoleLogic AccRoleLogic;
        protected IAccountmodeLogic AccountmodeLogic;
        protected IFailedloginattemptLogic FailedloginattemptLogic;
        protected IResetpasswordLogic ResetpasswordLogic;
        protected IEmailManager EmailManager = new EmailManager("pl");

        public const int WhiteMode = 1;
        public const int DarkMode = 2;
        //public const int BlueMode = 2;

        public WheeloAccountService(AuthenticationSettings authenticationSettings, IAccountLogic accLogic, IAccountRoleLogic accRoleLogic, 
            IAccountmodeLogic accountmodeLogic, 
            IFailedloginattemptLogic failedloginattemptLogic, IResetpasswordLogic resetpasswordLogic
            /*, IEmailManager emailManager*/)
        {
            _authenticationSettings = authenticationSettings;
            AccLogic = accLogic;
            AccRoleLogic = accRoleLogic;
            AccountmodeLogic = accountmodeLogic;
            FailedloginattemptLogic = failedloginattemptLogic;
            ResetpasswordLogic = resetpasswordLogic;
            //EmailManager = emailManager;
        }

        public ReturnedResponse<AccountRoleDto> Login(LoginDto loginDto)
        {
            Accountrole simpleaccount = AccRoleLogic.Select(m => m.Email == loginDto.Email && m.Password == loginDto.Password).FirstOrDefault();

            if (simpleaccount == null)
            {
                Accountrole emailAccount = AccRoleLogic.Select(m => m.Email == loginDto.Email).FirstOrDefault();

                if (emailAccount != null)
                {
                    FailedloginattemptLogic.Insert(new Failedloginattempt() { Idaccount = emailAccount.Id.Value });

                    bool isHack = FailedloginattemptLogic.Select(m => m.Idaccount == emailAccount.Id.Value && m.Createdat > DateTime.Now.AddSeconds(-15)).Count() > 5;

                    if (isHack)
                    {
                        return new ReturnedResponse<AccountRoleDto>(null, I18nTranslation.Translation(I18nTags.UnderAttack), false, ErrorCodes.UnderAttack);
                    }
                }

                return new ReturnedResponse<AccountRoleDto>(null, I18nTranslation.Translation(I18nTags.AccountNotFound), false, ErrorCodes.AccountNotFound);
            }

            if (!simpleaccount.Emailconfirmed.Value && simpleaccount.Password == loginDto.Password)
            {
                return new ReturnedResponse<AccountRoleDto>(null, I18nTranslation.Translation(I18nTags.EmailIsNotConfirmed), false, ErrorCodes.EmailIsNotConfirmedPassMatch);
            }

            if (!simpleaccount.Emailconfirmed.Value)
            {
                Account accToRefreshCode = AccLogic.Select(m => m.Id == simpleaccount.Id).First();

                accToRefreshCode.Verificationcode = IntUtils.GetRandomCode(1000, 9999);

                accToRefreshCode = AccLogic.Update(accToRefreshCode);

                EmailManager.SendEmailVerificationCode(accToRefreshCode.Email, accToRefreshCode.Name, accToRefreshCode.Verificationcode.Value.ToString());

                return new ReturnedResponse<AccountRoleDto>(null, I18nTranslation.Translation(I18nTags.EmailIsNotConfirmed), false, ErrorCodes.EmailIsNotConfirmed);
            }

            string refreshToken = simpleaccount.Refreshtoken;

            if (simpleaccount.Refreshtokenvalid == null || simpleaccount.Refreshtokenvalid < DateTime.Now)
            {
                Account accToRefreshToken = AccLogic.Select(m => m.Id == simpleaccount.Id).First();

                accToRefreshToken.Refreshtokenvalid = DateTime.Now.AddDays(AccountLogicConstants.RefreshTokenValidDays); 
                refreshToken = accToRefreshToken.Refreshtoken = StringUtils.GetRandomString(AccountLogicConstants.RefreshTokenMaxLength);

                AccLogic.Update(accToRefreshToken);
            }

            AccountRoleDto resultAccRole = GenerateJwt(new LoginDto() { Email = simpleaccount.Email, Password = simpleaccount.Password });

            resultAccRole.Refreshtoken = refreshToken;

            return new ReturnedResponse<AccountRoleDto>(resultAccRole, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<AccountRegisterDto> Register(AccountRegisterDto sAccount)
        {
            Account simpleaccount = AccLogic.Select(m => m.Email == sAccount.Email).FirstOrDefault();

            if (simpleaccount != null)
            {
                if (!simpleaccount.Emailconfirmed.Value && simpleaccount.Password == sAccount.Password)
                {
                    return new ReturnedResponse<AccountRegisterDto>(null, I18nTranslation.Translation(I18nTags.PleaseConfirmYourWheeloAccountRegistration), false, ErrorCodes.PleaseConfirmEmail);
                }

                if (simpleaccount.Emailconfirmed.Value && simpleaccount.Password == sAccount.Password)
                {
                    return new ReturnedResponse<AccountRegisterDto>(null, I18nTranslation.Translation(I18nTags.PleaseLogIn), false, ErrorCodes.PleaseLogIn);
                }

                return new ReturnedResponse<AccountRegisterDto>(null, I18nTranslation.Translation(I18nTags.AccountExists), false, ErrorCodes.AccountExists);
            }

            Account account = new Account() { Name = sAccount.FirstName, 
                Surname = sAccount.LastName, Password = sAccount.Password, Email = sAccount.Email };

            account.Verificationcode = IntUtils.GetRandomCode(1000, 9999);

            simpleaccount = AccLogic.Insert(account);

            EmailManager.SendEmailVerificationCode(account.Email, account.Name, simpleaccount.Verificationcode.Value.ToString());

            simpleaccount.Verificationcode = 0;

            return new ReturnedResponse<AccountRegisterDto>(sAccount, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<AccountRoleDto> ConfirmEmail(EmailConfirmDto EcDto)
        {
            Account account = AccLogic.Select(m => m.Email == EcDto.Email && m.Verificationcode == EcDto.Code).FirstOrDefault();

            if (account == null)
            {
                return new ReturnedResponse<AccountRoleDto>(null, I18nTranslation.Translation(I18nTags.FailVerifyingAccount), false, ErrorCodes.FailVerifyingAccount);
            }

            account.Emailconfirmed = true;
            string refreshToken = account.Refreshtoken = StringUtils.GetRandomString(AccountLogicConstants.RefreshTokenMaxLength);
            account.Refreshtokenvalid = DateTime.Now.AddDays(AccountLogicConstants.RefreshTokenValidDays);

            AccLogic.Update(account);

            AccountRoleDto accountRoleDto = GenerateJwt(new LoginDto() { Email = account.Email, Password = account.Password });

            accountRoleDto.Refreshtoken = refreshToken;

            return new ReturnedResponse<AccountRoleDto>(accountRoleDto, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }


        public virtual ReturnedResponse<bool> GetMode(int accountId)
        {
            Accountmode mode = AccountmodeLogic.Select(m => m.Idaccount == accountId).FirstOrDefault();

            if (mode == null)
            {
                AccountmodeLogic.Insert(new Accountmode() { Idaccount = accountId, Mode = WhiteMode });

                return new ReturnedResponse<bool>(false, I18nTranslation.Translation(I18nTags.DefaultModeCreated), true, ErrorCodes.Success);
            }

            return new ReturnedResponse<bool>(mode.Mode == WhiteMode ? false : true, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<bool> SetMode(int accountId, bool mode)
        {
            Accountmode accMode = AccountmodeLogic.Select(m => m.Idaccount == accountId).FirstOrDefault();

            if (accMode == null)
            {
                AccountmodeLogic.Insert(new Accountmode() { Idaccount = accountId, Mode = mode ? WhiteMode : DarkMode });

                return new ReturnedResponse<bool>(mode, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
            }

            accMode.Mode = mode ? WhiteMode : DarkMode;

            AccountmodeLogic.Update(accMode);

            return new ReturnedResponse<bool>(mode, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<AccountRoleDto> AcceptResetPassword(ResetPasswordConfirmDto resetPasswordConfirmDto) // email, kod
        {
             Resetpassword resPwd = ResetpasswordLogic.Select(m => m.Email == resetPasswordConfirmDto.Email && m.Verificationcode == resetPasswordConfirmDto.Code).FirstOrDefault();

            if (resPwd == null)
            {
                return new ReturnedResponse<AccountRoleDto>(null, I18nTranslation.Translation(I18nTags.FailVerifyingAccount), false, ErrorCodes.FailVerifyingAccount);
            }

            Account account = AccLogic.Select(m => m.Email == resetPasswordConfirmDto.Email).FirstOrDefault();

            if (account == null)
            {
                return new ReturnedResponse<AccountRoleDto>(null, I18nTranslation.Translation(I18nTags.FailVerifyingAccount), false, ErrorCodes.FailVerifyingAccount);
            }

            account.Password = resetPasswordConfirmDto.Password;

            AccLogic.Update(account);

            return Login(new LoginDto() { Email = resetPasswordConfirmDto.Email, Password = resetPasswordConfirmDto.Password });
        }

        public virtual ReturnedResponse<int> RequestPasswordReset(string email)
        {
            //check if email exists in accounts
            Account acc = AccLogic.Select(m => m.Email == email).FirstOrDefault();
            // if not return with significant error code

            if (acc == null)
            {
                return new ReturnedResponse<int>(ErrorCodes.EmailDoesNotExistResetPassword, I18nTranslation.Translation(I18nTags.EmailDoesNotExist), false, ErrorCodes.EmailDoesNotExistResetPassword);
            }

            int verificationCode = IntUtils.GetRandomCode(1000, 9999);

            // if exists, generate a code and stor4e record with ResetpasswordLogic.Insert 
            Resetpassword resetpassword = new Resetpassword() { Email = email, Verificationcode = verificationCode };

            ResetpasswordLogic.Insert(resetpassword);

            //send Email 
            EmailManager.SendPasswordResetVerificationCode(email, acc.Name, verificationCode.ToString());

            return new ReturnedResponse<int>(ErrorCodes.Success, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success); 
        }

        public ReturnedResponse<int> ResetPassword(string email, string password, string token)
        {
            Account acc = AccLogic.Select(m => m.Email == email).FirstOrDefault();
            // if not return with significant error code

            if (acc == null)
            {
                return new ReturnedResponse<int>(ErrorCodes.EmailDoesNotExistResetPassword, I18nTranslation.Translation(I18nTags.EmailDoesNotExist), false, ErrorCodes.EmailDoesNotExistResetPassword);
            }

            Resetpassword resetpassword = ResetpasswordLogic.Select(m => m.Email == email && m.Verificationcode.ToString() == token).FirstOrDefault();

            if (resetpassword == null)
            {
                return new ReturnedResponse<int>(ErrorCodes.FailVerifyingAccount, I18nTranslation.Translation(I18nTags.FailVerifyingAccount), false, ErrorCodes.FailVerifyingAccount);
            }

            acc.Password = password;

            AccLogic.Update(acc);

            return new ReturnedResponse<int>(ErrorCodes.Success, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public ReturnedResponse<TokensModel> CreateNewAccessToken(string accessToken, string refreshToken)
        {
            ClaimsPrincipal clPr = GetPrincipalFromExpiredToken(accessToken);

            string email = clPr.Claims.Where(claim => claim.Type == ClaimTypes.NameIdentifier).First().Value;

            Account account = AccLogic.Select(m => m.Email == email).First();

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

            AccLogic.Update(account);

            return new ReturnedResponse<TokensModel>(tokensModel, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public List<Account> GetAllUsers() // TODO REMOVE
        {
            return AccLogic.Select(m => true).ToList();
        }

        protected AccountRoleDto GenerateJwt(LoginDto user)
        {
            Accountrole userRole = AccRoleLogic.Select(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();

            if (userRole is null)
            {
                //throw new Exception("Invalid username or password");
                //throw new BadRequestException("Invalid username or password");
                return null;
            }

            AccountRoleDto userArd = DtoModelMapper.Map<AccountRoleDto, Accountrole>(userRole);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, userArd.Email),
                new Claim(ClaimTypes.Name, $"{userArd.Name} {userArd.Surname}"),
                new Claim(ClaimTypes.Role, $"{userArd.Rolename}"),
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            SigningCredentials cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            DateTime expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            JwtSecurityToken token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer, claims, expires: expires, signingCredentials: cred);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            userArd.AccessToken = tokenHandler.WriteToken(token);

            return userArd;
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
    }
}
