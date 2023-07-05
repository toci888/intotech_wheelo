usignsad

asdasdasd

public class VaccountscollocationDtoLogic : DtoLogicBase<VaccountscollocationModelDto, Vaccountscollocation, IVaccountscollocationLogic, VaccountscollocationDto, List<Vaccountscollocation>, List<VaccountscollocationModelDto>>
{
    public VaccountscollocationDtoLogic(IVaccountscollocationLogic vaccountscollocationlogic) 
        : base(vaccountscollocationlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Vaccountscollocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vaccountscollocation,VaccountscollocationDto> GetDtoModelField(VaccountscollocationDto dto)
    {
       return dto.Vaccountscollocation;
    }

    protected override VaccountscollocationDto FillEntity(VaccountscollocationDto dto, DtoBase<Vaccountscollocation> field)
    {
        dto.Vaccountscollocation = (VaccountscollocationModelDto)field;

        return dto;
    }
}
