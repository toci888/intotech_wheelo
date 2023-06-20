using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class AccountslocationDtoLogic : DtoLogicBase< AccountslocationModelDto , Accountslocation , AccountslocationLogic , AccountslocationDto >
{
    public AccountslocationDtoLogic(int id) 
        : base(new AccountslocationLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Accountslocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Accountslocation> GetDtoModelField(AccountslocationDto dto)
    {
       return dto.Accountslocation;
    }

    protected override AccountslocationDto FillEntity(AccountslocationDto dto, DtoBase<Accountslocation> field)
    {
        dto.Accountslocation = (AccountslocationModelDto)field;

        return dto;
    }
}
