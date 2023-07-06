using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic;

public class RoleDtoLogic : DtoLogicBase<RoleModelDto, Role, IRoleLogic, RoleDto, List<Role>, List<RoleModelDto>>
{
    public RoleDtoLogic(IRoleLogic rolelogic) 
        : base(rolelogic, 
            (aDto, aModelDto) => { 
                aDto.Role = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Role,RoleModelDto> GetDtoModelField(RoleDto dto)
    {
       return dto.Role;
    }

    protected override RoleDto FillEntity(RoleDto dto, RoleModelDto  field)
    {
        dto.Role = field;

        return dto;
    }    protected override RoleDto FillEntity(RoleDto dto, List<RoleModelDto> field)
    {
        throw new NotImplementedException();
    }
}
