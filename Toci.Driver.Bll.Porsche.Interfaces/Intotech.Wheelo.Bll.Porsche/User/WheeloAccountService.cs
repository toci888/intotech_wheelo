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

namespace Intotech.Wheelo.Bll.Porsche.User
{
    public class WheeloAccountService : IWheeloAccountService
    {
        protected IAccountLogic AccLogic;
        protected IAccountRoleLogic AccRoleLogic;
        protected IAccountmodeLogic AccountmodeLogic;
        protected IFailedloginattemptLogic FailedloginattemptLogic;
        protected IEmailManager EmailManager = new EmailManager("pl");

        public const int WhiteMode = 0;
        public const int DarkMode = 1;
        public const int BlueMode = 2;

        public WheeloAccountService(IAccountLogic accLogic, IAccountRoleLogic accRoleLogic, IAccountmodeLogic accountmodeLogic, 
            IFailedloginattemptLogic failedloginattemptLogic
            /*, IEmailManager emailManager*/)
        {
            AccLogic = accLogic;
            AccRoleLogic = accRoleLogic;
            AccountmodeLogic = accountmodeLogic;
            FailedloginattemptLogic = failedloginattemptLogic;
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

            Accountrole resultAccRole = AccRoleLogic.GenerateJwt(new LoginDto() { Email = simpleaccount.Email, Password = simpleaccount.Password });

            AccountRoleDto accountRoleDto = DtoModelMapper.Map<AccountRoleDto, Accountrole>(resultAccRole);

            accountRoleDto.RefreshToken = refreshToken;

            return new ReturnedResponse<AccountRoleDto>(accountRoleDto, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<AccountRegisterDto> Register(AccountRegisterDto sAccount)
        {
            Account simpleaccount = AccLogic.Select(m => m.Email == sAccount.Email).FirstOrDefault();

            if (simpleaccount != null)
            {
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

        public ReturnedResponse<AccountRoleDto> ConfirmEmail(EmailConfirmDto EcDto)
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

            Accountrole resultAccRole = AccRoleLogic.GenerateJwt(new LoginDto() { Email = account.Email, Password = account.Password });

            AccountRoleDto accountRoleDto = DtoModelMapper.Map<AccountRoleDto, Accountrole>(resultAccRole);

            accountRoleDto.RefreshToken = refreshToken;

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
    }
}
