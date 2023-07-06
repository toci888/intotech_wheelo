using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;

namespace Intotech.Wheelo.Bll.Logic;

public class AccountmetadatumDtoLogic : DtoLogicBase<AccountmetadatumModelDto, Accountmetadatum, IAccountmetadatumLogic, AccountmetadatumDto, List<Accountmetadatum>, List<AccountmetadatumModelDto>>, IAccountmetadatumDtoLogic
{
    public AccountmetadatumDtoLogic(IAccountmetadatumLogic accountmetadatumlogic) 
        : base(accountmetadatumlogic, 
            (aDto, aModelDto) => { 
                aDto.Accountmetadatum = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Accountmetadatum,AccountmetadatumModelDto> GetDtoModelField(AccountmetadatumDto dto)
    {
       return dto.Accountmetadatum;
    }

    protected override AccountmetadatumDto FillEntity(AccountmetadatumDto dto, AccountmetadatumModelDto  field)
    {
        dto.Accountmetadatum = field;

        return dto;
    }    protected override AccountmetadatumDto FillEntity(AccountmetadatumDto dto, List<AccountmetadatumModelDto> field)
    {
        throw new NotImplementedException();
    }
}
