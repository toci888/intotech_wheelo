using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class AccountscollocationDtoLogic : DtoLogicBase< AccountscollocationModelDto , Accountscollocation , AccountscollocationLogic , AccountscollocationDto >
{
    public AccountscollocationDtoLogic(int id) 
        : base(new AccountscollocationLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Accountscollocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Accountscollocation> GetDtoModelField(AccountscollocationDto dto)
    {
       return dto.Accountscollocation;
    }

    protected override AccountscollocationDto FillEntity(AccountscollocationDto dto, DtoBase<Accountscollocation> field)
    {
        dto.Accountscollocation = (AccountscollocationModelDto)field;

        return dto;
    }
}
