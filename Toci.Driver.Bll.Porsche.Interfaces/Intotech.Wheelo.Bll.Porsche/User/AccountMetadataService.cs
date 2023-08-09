using Intotech.Common.Bll;
using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Interfaces;
using Intotech.Wheelo.Bll.Models.OldModels;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.User;
using Intotech.Wheelo.Common;
using Intotech.Wheelo.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.User
{
    public class AccountMetadataService : ServiceBaseEx, IAccountMetadataService
    {
        protected IAccountmetadatumLogic AccountMetaLogic;
        protected IOccupationLogic OccupationLogic;
        protected IGeographicregionLogic GeographicRegionLogic;

        public AccountMetadataService(
            IAccountmetadatumLogic accountMetaLogic,
            IOccupationLogic occupationLogic,
            IGeographicregionLogic geographicRegionLogic,
            ITranslationEngineI18n i18nTranslation) : base(i18nTranslation)
        {
            AccountMetaLogic = accountMetaLogic;
            OccupationLogic = occupationLogic;
            GeographicRegionLogic = geographicRegionLogic;
        }

        public virtual ReturnedResponse<AccountMetadataDto> Create(AccountMetadataDto entityDto)
        {
            Accountmetadatum modelCheck = AccountMetaLogic.Select(m => m.Idaccount == entityDto.AccountId).FirstOrDefault();

            if (modelCheck != null)
            {
                return new ReturnedResponse<AccountMetadataDto>(entityDto, I18nTranslation.Translate(entityDto.Language, I18nTags.DataAlreadyExistInDatabase), false, ErrorCodes.DataAlreadyExistInDatabase);
            }

            Accountmetadatum model = GetAccountmetadatum(entityDto);

            model = AccountMetaLogic.Insert(model);

            if (model.Id < 1)
            {
                return new ReturnedResponse<AccountMetadataDto>(entityDto, I18nTranslation.Translate(entityDto.Language, I18nTags.FailedToAddInformation), false, ErrorCodes.FailedToAddInformation);
            }

            return new ReturnedResponse<AccountMetadataDto>(entityDto, I18nTranslation.Translate(entityDto.Language, I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<AccountMetadataDto> Update(AccountMetadataDto entityDto)
        {
            Accountmetadatum modelCheck = AccountMetaLogic.Select(m => m.Idaccount == entityDto.AccountId).FirstOrDefault();

            if (modelCheck != null)
            {
                Accountmetadatum model = GetAccountmetadatum(entityDto);
                
                model.Id = modelCheck.Id;
                model.Createdat = modelCheck.Createdat;

                model = AccountMetaLogic.Update(model);

                return new ReturnedResponse<AccountMetadataDto>(entityDto, I18nTranslation.Translate(entityDto.Language, I18nTags.Success), true, ErrorCodes.Success);
            }

            Accountmetadatum modelIns = GetAccountmetadatum(entityDto);

            modelIns = AccountMetaLogic.Insert(modelIns);

            return new ReturnedResponse<AccountMetadataDto>(entityDto, I18nTranslation.Translate(entityDto.Language, I18nTags.Success), true, ErrorCodes.Success);
        }

        protected virtual Accountmetadatum GetAccountmetadatum(AccountMetadataDto entityDto)
        {
            Accountmetadatum model = MapDtoToModel(entityDto);

            Geographicregion geographicregion = GeographicRegionLogic.Select(m => m.Name == entityDto.City).FirstOrDefault();

            if (geographicregion != null)
            {
                model.Idgeographicregion = geographicregion.Id;
            }

            Occupation occupation = OccupationLogic.Select(m => m.Name == entityDto.Occupation).FirstOrDefault();

            if (occupation != null)
            {
                model.Idoccupation = occupation.Id;
            }

            return model;
        }

        protected virtual Accountmetadatum MapDtoToModel(AccountMetadataDto dto)
        {
            return new Accountmetadatum() 
            {
                Gender = dto.Gender,
                Idaccount = dto.AccountId,
                Issmoker = dto.IsSmoker,
                Iswithanimals = dto.IsWithAnimals,
                Pesel = dto.Pesel,
                Phone = dto.Phone,
                Metajson = dto.MetaJson
            };
        }
    }
}
