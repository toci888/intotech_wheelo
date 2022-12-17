using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Models;
using Intotech.Wheelo.Bll.Models.TripCollocation;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Persistence.Interfaces.SubServices;
using Intotech.Wheelo.Common;
using Intotech.Wheelo.Common.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Persistence.SubServices
{
    public class AssociationMapDataSubService : IAssociationMapDataSubService
    {
        protected IVacollocationsgeolocationLogic VacollocationsgeolocationLogic;
        protected IVcollocationsgeolocationLogic VcollocationsgeolocationLogic;


        public AssociationMapDataSubService(IVacollocationsgeolocationLogic vacollocationsgeolocationLogic,
            IVcollocationsgeolocationLogic vcollocationsgeolocationLogic)
        {
            VacollocationsgeolocationLogic = vacollocationsgeolocationLogic;
            VcollocationsgeolocationLogic = vcollocationsgeolocationLogic;
        }

        public virtual ReturnedResponse<Vcollocationsgeolocation> GetCollocationUser(int accountId)
        {
            Vcollocationsgeolocation collocationSource = VcollocationsgeolocationLogic.Select(m => m.Accountid == accountId).FirstOrDefault();

            return new ReturnedResponse<Vcollocationsgeolocation>(collocationSource, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<TripCollocationDto> GetTripCollocation(int accountId, string searchId)
        {
            TripCollocationDto resultDto = new TripCollocationDto();

            Vcollocationsgeolocation collocationSource = VcollocationsgeolocationLogic.Select(m => m.Accountid == accountId).FirstOrDefault();

            if (collocationSource == null)
            {
                return new ReturnedResponse<TripCollocationDto>(resultDto, I18nTranslation.Translation(I18nTags.NoData), false, ErrorCodes.NoData);
            }

            resultDto.SourceAccount = collocationSource;
            //&& m.Searchid == searchId
            //get collocated accounts
            resultDto.AccountsCollocated = VacollocationsgeolocationLogic.Select(m => m.Idaccount == accountId).ToList();

            return new ReturnedResponse<TripCollocationDto>(resultDto, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }


    }
}
