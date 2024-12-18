﻿using Intotech.Common;
using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Models.Account;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.User;
using Intotech.Wheelo.Common.Interfaces;
using Intotech.Wheelo.Common;
using Npgsql.Internal.TypeMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.User
{
    public class UserMetaService : IUserMetaService
    {
        protected IOccupationSmokerCratLogic OccSmoCrLogic;

        public UserMetaService(IOccupationSmokerCratLogic occSmoCrLogic)
        {
            OccSmoCrLogic = occSmoCrLogic;
        }

        public ReturnedResponse<SmokerOccupationDto> SetSmokerOccupation(SmokerOccupationDto smokerOccupationDto)
        {
            Occupationsmokercrat model = DtoModelMapper.Map<Occupationsmokercrat, SmokerOccupationDto>(smokerOccupationDto);

            Occupationsmokercrat exists = OccSmoCrLogic.Select(m => m.Idaccount == smokerOccupationDto.Idaccount).FirstOrDefault();

            if (exists != null)
            {
                model.Id = exists.Id;

                OccSmoCrLogic.Update(model);

                return new ReturnedResponse<SmokerOccupationDto>(smokerOccupationDto, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
            }

            OccSmoCrLogic.Insert(model);

            return new ReturnedResponse<SmokerOccupationDto>(smokerOccupationDto, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }
    }
}
