using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;


namespace Intotech.Wheelo.Bll.Logic;


public class AccountscollocationDtoLogic : DtoLogicBase<AccountscollocationModelDto, Accountscollocation, IAccountscollocationLogic, AccountscollocationDto, List<Accountscollocation>, List<AccountscollocationModelDto>>, IAccountscollocationDtoLogic
{
    public AccountscollocationDtoLogic(IAccountscollocationLogic accountscollocationlogic) 
        : base(accountscollocationlogic, 
            (aDto, aModelDto) => { 
                aDto.Accountscollocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override AccountscollocationModelDto GetDtoModelField(AccountscollocationDto dto)
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
