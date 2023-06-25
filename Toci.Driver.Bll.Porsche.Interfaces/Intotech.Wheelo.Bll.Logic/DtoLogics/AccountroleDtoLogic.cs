using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class AccountroleDtoLogic : DtoLogicBase< AccountroleModelDto , Accountrole , AccountroleLogic , AccountroleDto >
{
    public AccountroleDtoLogic(int id) 
        : base(new AccountroleLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Accountrole = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Accountrole> GetDtoModelField(AccountroleDto dto)
    {
       return dto.Accountrole;
    }

    protected override AccountroleDto FillEntity(AccountroleDto dto, DtoBase<Accountrole> field)
    {
        dto.Accountrole = (AccountroleModelDto)field;

        return dto;
    }
}
