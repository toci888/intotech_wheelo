using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Models.TripCollocation;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Association;
using Intotech.Wheelo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.Association
{
    public class AssociationMapDataService : IAssociationMapDataService
    {
        protected IVacollocationsgeolocationLogic VacollocationsgeolocationLogic;
        protected IVcollocationsgeolocationLogic VcollocationsgeolocationLogic;

        public AssociationMapDataService(IVacollocationsgeolocationLogic vacollocationsgeolocationLogic, IVcollocationsgeolocationLogic vcollocationsgeolocationLogic)
        {
            VacollocationsgeolocationLogic = vacollocationsgeolocationLogic;
            VcollocationsgeolocationLogic = vcollocationsgeolocationLogic;
        }

        public virtual ReturnedResponse<TripCollocationDto> GetTripCollocation(int accountId)
        {
            TripCollocationDto resultDto = new TripCollocationDto();

            Vcollocationsgeolocation collocationSource = VcollocationsgeolocationLogic.Select(m => m.Accountid == accountId).FirstOrDefault();

            if (collocationSource == null)
            {
                return new ReturnedResponse<TripCollocationDto>(resultDto, I18nTranslation.Translation(I18nTags.NoData), false);
            }

            resultDto.SourceAccount = collocationSource;

            resultDto.AccountsCollocated = VacollocationsgeolocationLogic.Select(m => m.Idaccount == accountId).ToList();

            return new ReturnedResponse<TripCollocationDto>(resultDto, I18nTranslation.Translation(I18nTags.Success), true);
        }
    }
}
