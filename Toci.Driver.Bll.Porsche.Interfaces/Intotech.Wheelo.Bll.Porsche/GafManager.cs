using Intotech.Wheelo.Bll.Models;
using Intotech.Wheelo.Bll.Models.Account;
using Intotech.Wheelo.Bll.Models.Gaf;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces;
using Intotech.Wheelo.Bll.Porsche.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche
{
    public class GafManager : IGafManager
    {
        protected IUserExtraDataLogic LUserExtraDataLogic;
        protected IAccountRoleLogic AccLogic;
        protected GafServiceBase<FacebookUserDto> FbGafService;

        public GafManager(IUserExtraDataLogic lUserExtraDataLogic, IAccountRoleLogic accLogic, GafServiceBase<FacebookUserDto> fbGafService)
        {
            LUserExtraDataLogic = lUserExtraDataLogic;
            AccLogic = accLogic;
            FbGafService = fbGafService;
        }

        public virtual Accountrole RegisterByMethod(string method, string token)
        {
            if (method == "google")
            {
                GoogleUserDto dto = new GoogleUserService().GetUserByToken(token);

                return GoogleAccountExtraData(dto, token);
            }

            if (method == "facebook")
            {
                FacebookUserDto dto = FbGafService.GetUserByToken(token);

                return AccLogic.Select(m => m.Email == dto.email).FirstOrDefault();
            }

            return null;
        }

        protected virtual Accountrole GoogleAccountExtraData(GoogleUserDto dto, string token)
        {
            Accountrole accountrole = new Accountrole(); //= AccLogic.CreateAccount(new AccountRegisterDto() { Email = dto.email, Firstname = dto.name, Lastname = dto.given_name  });

            LUserExtraDataLogic.Insert(new Userextradatum() { Idaccount = accountrole.Id, Token = token });

            return accountrole;
        }

        
    }
}
