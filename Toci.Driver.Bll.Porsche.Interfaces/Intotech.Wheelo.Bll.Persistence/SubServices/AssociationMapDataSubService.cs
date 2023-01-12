using Intotech.Common;
using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Models;
using Intotech.Wheelo.Bll.Models.ModelMappers;
using Intotech.Wheelo.Bll.Models.TripCollocation;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Persistence.Interfaces.SubServices;
using Intotech.Wheelo.Common;
using Intotech.Wheelo.Common.Interfaces;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Intotech.Wheelo.Common.Interfaces.Models;
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
        protected IVacollocationsgeolocationToAccountCollocationDto VacollocationsgeolocationToAccountCollocation;


        public AssociationMapDataSubService(IVacollocationsgeolocationLogic vacollocationsgeolocationLogic,
            IVcollocationsgeolocationLogic vcollocationsgeolocationLogic,
            IVacollocationsgeolocationToAccountCollocationDto vacollocationsgeolocationToAccountCollocationDto)
        {
            VacollocationsgeolocationLogic = vacollocationsgeolocationLogic;
            VcollocationsgeolocationLogic = vcollocationsgeolocationLogic;
            VacollocationsgeolocationToAccountCollocation = vacollocationsgeolocationToAccountCollocationDto;
        }

        public virtual ReturnedResponse<AccountCollocationDto> GetCollocationUser(int accountId)
        {
            Vacollocationsgeolocation collocationSource = VacollocationsgeolocationLogic.Select(m => m.Accountidcollocated == accountId).FirstOrDefault();

            if (collocationSource != null)
            {
                AccountCollocationDto result = VacollocationsgeolocationToAccountCollocation.Map(collocationSource, accountId);

                return new ReturnedResponse<AccountCollocationDto>(result, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
            }
        
            return new ReturnedResponse<AccountCollocationDto>(null, I18nTranslation.Translation(I18nTags.NoData), false, ErrorCodes.NoData);
        }

        public virtual ReturnedResponse<TripCollocationDto> GetTripCollocation(int accountId, string searchId) // DEPRECATED
        {
            TripCollocationDto resultDto = new TripCollocationDto();

            Vcollocationsgeolocation collocationSource = VcollocationsgeolocationLogic.Select(m => m.Idaccount == accountId).FirstOrDefault();

            if (collocationSource == null)
            {
                return new ReturnedResponse<TripCollocationDto>(resultDto, I18nTranslation.Translation(I18nTags.NoData), false, ErrorCodes.NoData);
            }

            resultDto.SourceAccount = collocationSource;
            resultDto.AccountsCollocated = VacollocationsgeolocationLogic.Select(m => m.Idaccount == accountId).ToList();

            return new ReturnedResponse<TripCollocationDto>(resultDto, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }


    }
}
