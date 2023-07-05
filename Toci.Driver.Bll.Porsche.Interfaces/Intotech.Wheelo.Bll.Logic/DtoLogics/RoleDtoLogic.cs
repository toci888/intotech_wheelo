usignsad

asdasdasd

public class RoleDtoLogic : DtoLogicBase<RoleModelDto, Role, IRoleLogic, RoleDto, List<Role>, List<RoleModelDto>>
{
    public RoleDtoLogic(IRoleLogic rolelogic) 
        : base(rolelogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Role = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Role,RoleDto> GetDtoModelField(RoleDto dto)
    {
       return dto.Role;
    }

    protected override RoleDto FillEntity(RoleDto dto, DtoBase<Role> field)
    {
        dto.Role = (RoleModelDto)field;

        return dto;
    }
}
