using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic;

public class AccountscollocationDtoLogic : DtoLogicBase<AccountscollocationModelDto, Accountscollocation, IAccountscollocationLogic, AccountscollocationDto, List<Accountscollocation>, List<AccountscollocationModelDto>>
{
    public AccountscollocationDtoLogic(IAccountscollocationLogic accountscollocationlogic) 
        : base(accountscollocationlogic, 
            (aDto, aModelDto) => { 
                aDto.Accountscollocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Accountscollocation,AccountscollocationModelDto> GetDtoModelField(AccountscollocationDto dto)
    {
       return dto.Accountscollocation;
    }

    protected override AccountscollocationDto FillEntity(AccountscollocationDto dto, AccountscollocationModelDto  field)
    {
        dto.Accountscollocation = field;

        return dto;
    }    protected override AccountscollocationDto FillEntity(AccountscollocationDto dto, List<AccountscollocationModelDto> field)
    {
        throw new NotImplementedException();
    }
}
