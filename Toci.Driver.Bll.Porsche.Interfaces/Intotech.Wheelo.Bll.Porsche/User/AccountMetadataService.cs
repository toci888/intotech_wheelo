using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Models.Account;
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
    public class AccountMetadataService : IAccountMetadataService
    {
        protected IAccountMetadataLogic AccountMetaLogic;
        protected IOccupationLogic OccupationLogic;
        protected IGeographicRegionLogic GeographicRegionLogic;

        public AccountMetadataService(IAccountMetadataLogic accountMetaLogic, IOccupationLogic occupationLogic, IGeographicRegionLogic geographicRegionLogic)
        {
            AccountMetaLogic = accountMetaLogic;
            OccupationLogic = occupationLogic;
            GeographicRegionLogic = geographicRegionLogic;
        }

        public virtual ReturnedResponse<AccountMetadataDto> Create(AccountMetadataDto accountMetaDto)
        {
            Accountmetadatum model = MapDtoToModel(accountMetaDto);

            Geographicregion geographicregion = GeographicRegionLogic.Select(m => m.Name == accountMetaDto.City).FirstOrDefault();

            if (geographicregion != null)
            {
                model.Idgeographicregion = geographicregion.Id;
            }

            Occupation occupation = OccupationLogic.Select(m => m.Name == accountMetaDto.Occupation).FirstOrDefault();

            if (occupation != null)
            {
                model.Idoccupation = occupation.Id;
            }

            model = AccountMetaLogic.Insert(model);

            if (model.Id < 1)
            {
                return new ReturnedResponse<AccountMetadataDto>(accountMetaDto, I18nTranslation.Translation(I18nTags.FailedToAddInformation), false);
            }

            return new ReturnedResponse<AccountMetadataDto>(accountMetaDto, I18nTranslation.Translation(I18nTags.Success), true);
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
