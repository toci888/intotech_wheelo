using Intotech.Wheelo.Bll.Models;
using Intotech.Wheelo.Bll.Models.Account;
using Intotech.Wheelo.Bll.Models.Gaf;
using Intotech.Wheelo.Bll.Persistence;
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
        protected IUserextradatumLogic LUserExtraDataLogic;
        protected IAccountroleLogic AccLogic;
        protected GafServiceBase<FacebookUserDto> FbGafService;
        protected GafServiceBase<GoogleUserDto> GoogleGafService;

        public GafManager(IUserextradatumLogic lUserExtraDataLogic, IAccountroleLogic accLogic, GafServiceBase<FacebookUserDto> fbGafService,
            GafServiceBase<GoogleUserDto> googleGafService)
        {
            LUserExtraDataLogic = lUserExtraDataLogic;
            AccLogic = accLogic;
            FbGafService = fbGafService;
            GoogleGafService = googleGafService;
        }

        public virtual Accountrole RegisterByMethod(string method, string token)
        {
            if (method == "google")
            {
                GoogleUserDto dto = GoogleGafService.GetUserByToken(token);

                if (dto == null)
                {
                    return null;
                }

                return AccLogic.Select(m => m.Email == dto.email).FirstOrDefault();
            }

            if (method == "facebook")
            {
                FacebookUserDto dto = FbGafService.GetUserByToken(token);

                if (dto == null)
                {
                    return null;
                }

                return AccLogic.Select(m => m.Email == dto.email).FirstOrDefault();
            }

            return null;
        }        
    }
}
