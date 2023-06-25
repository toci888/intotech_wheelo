using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class RoleDtoLogic : DtoLogicBase< RoleModelDto , Role , RoleLogic , RoleDto >
{
    public RoleDtoLogic(int id) 
        : base(new RoleLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Role = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Role> GetDtoModelField(RoleDto dto)
    {
       return dto.Role;
    }

    protected override RoleDto FillEntity(RoleDto dto, DtoBase<Role> field)
    {
        dto.Role = (RoleModelDto)field;

        return dto;
    }
}
