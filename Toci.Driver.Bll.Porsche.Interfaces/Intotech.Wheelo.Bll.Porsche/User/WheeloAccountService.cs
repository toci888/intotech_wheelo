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
        protected ISimpleAccountLogic SaLogic;

        public WheeloAccountService(ISimpleAccountLogic saLogic)
        {
            SaLogic = saLogic;
        }

        public ReturnedResponse<Simpleaccount> Login(LoginDto loginDto)
        {
            Simpleaccount simpleaccount = SaLogic.Select(m => m.Email == loginDto.Email && m.Password == loginDto.Password).FirstOrDefault();

            if (simpleaccount == null)
            {
                return new ReturnedResponse<Simpleaccount>(null, "Nie odnaleziono konta.", false);
            }

            return new ReturnedResponse<Simpleaccount>(simpleaccount, I18nTranslation.Translation(I18nTags.Success), true);
        }

        public virtual ReturnedResponse<Simpleaccount> Register(Simpleaccount sAccount)
        {
            Simpleaccount simpleaccount = SaLogic.Select(m => m.Email == sAccount.Email).FirstOrDefault();

            if (simpleaccount != null)
            {
                return new ReturnedResponse<Simpleaccount>(null, "Konto istnieje.", false);
            }

            sAccount.Verificationcode = IntUtils.GetRandomCode(1000, 9999);

            simpleaccount = SaLogic.Insert(sAccount);

            simpleaccount.Verificationcode = 0;

            return new ReturnedResponse<Simpleaccount>(simpleaccount, I18nTranslation.Translation(I18nTags.Success), true);
        }
    }
}
