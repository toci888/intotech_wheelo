using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;

namespace Intotech.Wheelo.Bll.Logic;

public class AccountslocationDtoLogic : DtoLogicBase<AccountslocationModelDto, Accountslocation, IAccountslocationLogic, AccountslocationDto, List<Accountslocation>, List<AccountslocationModelDto>>, IAccountslocationDtoLogic
{
    public AccountslocationDtoLogic(IAccountslocationLogic accountslocationlogic) 
        : base(accountslocationlogic, 
            (aDto, aModelDto) => { 
                aDto.Accountslocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Accountslocation,AccountslocationModelDto> GetDtoModelField(AccountslocationDto dto)
    {
       return dto.Accountslocation;
    }

    protected override AccountslocationDto FillEntity(AccountslocationDto dto, AccountslocationModelDto  field)
    {
        dto.Accountslocation = field;

        return dto;
    }    protected override AccountslocationDto FillEntity(AccountslocationDto dto, List<AccountslocationModelDto> field)
    {
        throw new NotImplementedException();
    }
}
