using Intotech.Common;
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

        public const int WhiteMode = 0;
        public const int DarkMode = 1;
        public const int BlueMode = 2;

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

            AccountRoleDto resultAccRole = AccRoleLogic.GenerateJwt(new LoginDto() { Email = simpleaccount.Email, Password = simpleaccount.Password });

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

            AccountRoleDto accountRoleDto = AccRoleLogic.GenerateJwt(new LoginDto() { Email = account.Email, Password = account.Password });

            accountRoleDto.Refreshtoken = refreshToken;

            return new ReturnedResponse<AccountRoleDto>(accountRoleDto, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }


        public virtual ReturnedResponse<Accountmode> GetMode(int accountId)
        {
            Accountmode mode = AccountmodeLogic.Select(m => m.Idaccount == accountId).FirstOrDefault();

            if (mode == null)
            {
                return new ReturnedResponse<Accountmode>(AccountmodeLogic.Insert(new Accountmode() { Idaccount = accountId, Mode = WhiteMode }),
                    I18nTranslation.Translation(I18nTags.DefaultModeCreated), true, ErrorCodes.Success);
            }

            return new ReturnedResponse<Accountmode>(mode, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<Accountmode> SetMode(int accountId, int mode)
        {
            Accountmode accMode = AccountmodeLogic.Select(m => m.Idaccount == accountId).FirstOrDefault();

            if (accMode == null)
            {
                return new ReturnedResponse<Accountmode>(AccountmodeLogic.Insert(new Accountmode() { Idaccount = accountId, Mode = mode }),
                    I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
            }

            accMode.Mode = mode;

            return new ReturnedResponse<Accountmode>(AccountmodeLogic.Update(accMode), 
                I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
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
            // if not return with significant error code
            // if exists, generate a code and stor4e record with ResetpasswordLogic.Insert 

            //send Email ??

            return new ReturnedResponse<int>(0, "", true, 0); // TODO
        }
    }
}
