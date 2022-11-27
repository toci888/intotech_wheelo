using Intotech.Common;
using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Models;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.User;
using Intotech.Wheelo.Common;
using System;
using System.Collections.Generic;
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

        public ReturnedResponse<Accountrole> Login(LoginDto loginDto)
        {
            Accountrole simpleaccount = AccRoleLogic.Select(m => m.Email == loginDto.Email && m.Password == loginDto.Password).FirstOrDefault();

            if (simpleaccount == null)
            {
                return new ReturnedResponse<Accountrole>(null, "Nie odnaleziono konta.", false);
            }

            return new ReturnedResponse<Accountrole>(simpleaccount, I18nTranslation.Translation(I18nTags.Success), true);
        }

        public virtual ReturnedResponse<Account> Register(AccountRegisterDto sAccount)
        {
            Account simpleaccount = AccLogic.Select(m => m.Email == sAccount.Email).FirstOrDefault();

            if (simpleaccount != null)
            {
                return new ReturnedResponse<Account>(null, "Konto istnieje.", false);
            }

            Account account = new Account() { Name = sAccount.Firstname, 
                Surname = sAccount.Lastname, Password = sAccount.Password, Email = sAccount.Email };

            account.Verificationcode = IntUtils.GetRandomCode(1000, 9999);

            simpleaccount = AccLogic.Insert(account);

            simpleaccount.Verificationcode = 0;

            return new ReturnedResponse<Account>(account, I18nTranslation.Translation(I18nTags.Success), true);
        }
    }
}
