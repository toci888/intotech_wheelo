using Intotech.Common;
using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Models.OldModels;
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
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Common.Bll;
using Intotech.Common.Interfaces;

namespace Intotech.Wheelo.Bll.Porsche.User
{
    public class UserMetaService : ServiceBaseEx, IUserMetaService
    {
        protected IOccupationsmokercratLogic OccSmoCrLogic;

        public UserMetaService(IOccupationsmokercratLogic occSmoCrLogic, ITranslationEngineI18n i18nTranslation) : base(i18nTranslation)
        {
            OccSmoCrLogic = occSmoCrLogic;
        }

        public ReturnedResponse<SmokerOccupationDto> SetSmokerOccupation(SmokerOccupationDto entityDto)
        {
            Occupationsmokercrat model = DtoModelMapper.Map<Occupationsmokercrat, SmokerOccupationDto>(entityDto);

            Occupationsmokercrat exists = OccSmoCrLogic.Select(m => m.Idaccount == entityDto.Idaccount).FirstOrDefault();

            if (exists != null)
            {
                model.Id = exists.Id;

                OccSmoCrLogic.Update(model);

                return new ReturnedResponse<SmokerOccupationDto>(entityDto, I18nTranslation.Translate(entityDto.Language, I18nTags.Success), true, ErrorCodes.Success);
            }

            OccSmoCrLogic.Insert(model);

            return new ReturnedResponse<SmokerOccupationDto>(entityDto, I18nTranslation.Translate(entityDto.Language, I18nTags.Success), true, ErrorCodes.Success);
        }
    }
}
