using Intotech.Common;
using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Models.Account;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.User;
using Intotech.Wheelo.Common;
using Intotech.Wheelo.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.User
{
    public class WheeloAccountService : IWheeloAccountService
    {
        protected IAccountLogic AccLogic;
        protected IAccountRoleLogic AccRoleLogic;


        public WheeloAccountService(IAccountLogic accLogic, IAccountRoleLogic accRoleLogic)
        {
            AccLogic = accLogic;
            AccRoleLogic = accRoleLogic;
        }

        public ReturnedResponse<AccountRoleDto> Login(LoginDto loginDto)
        {
            Accountrole simpleaccount = AccRoleLogic.Select(m => m.Email == loginDto.Email && m.Password == loginDto.Password).FirstOrDefault();

            if (simpleaccount == null)
            {
                return new ReturnedResponse<AccountRoleDto>(null, I18nTranslation.Translation(I18nTags.AccountNotFound), false, ErrorCodes.AccountNotFound);
            }

            if (!simpleaccount.Emailconfirmed.Value)
            {
                return new ReturnedResponse<AccountRoleDto>(null, I18nTranslation.Translation(I18nTags.EmailIsNotConfirmed), false, ErrorCodes.EmailIsNotConfirmed);
            }

            string refreshToken = simpleaccount.Token;

            if (simpleaccount.Refreshtokenvalid == null || simpleaccount.Refreshtokenvalid < DateTime.Now)
            {
                Account accToRefreshToken = AccLogic.Select(m => m.Id == simpleaccount.Id).First();

                accToRefreshToken.Refreshtokenvalid = DateTime.Now.AddDays(AccountLogicConstants.RefreshTokenValidDays); 
                refreshToken = accToRefreshToken.Token = StringUtils.GetRandomString(AccountLogicConstants.RefreshTokenMaxLength);

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
            string refreshToken = account.Token = StringUtils.GetRandomString(AccountLogicConstants.RefreshTokenMaxLength);
            account.Refreshtokenvalid = DateTime.Now.AddDays(AccountLogicConstants.RefreshTokenValidDays);

            AccLogic.Update(account);

            Accountrole resultAccRole = AccRoleLogic.GenerateJwt(new LoginDto() { Email = account.Email, Password = account.Password });

            AccountRoleDto accountRoleDto = DtoModelMapper.Map<AccountRoleDto, Accountrole>(resultAccRole);

            accountRoleDto.RefreshToken = refreshToken;

            return new ReturnedResponse<AccountRoleDto>(accountRoleDto, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }
    }
}
