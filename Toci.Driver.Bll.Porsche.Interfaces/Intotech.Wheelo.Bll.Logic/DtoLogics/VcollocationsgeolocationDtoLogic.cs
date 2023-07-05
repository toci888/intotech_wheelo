usignsad

asdasdasd

public class VcollocationsgeolocationDtoLogic : DtoLogicBase<VcollocationsgeolocationModelDto, Vcollocationsgeolocation, IVcollocationsgeolocationLogic, VcollocationsgeolocationDto, List<Vcollocationsgeolocation>, List<VcollocationsgeolocationModelDto>>
{
    public VcollocationsgeolocationDtoLogic(IVcollocationsgeolocationLogic vcollocationsgeolocationlogic) 
        : base(vcollocationsgeolocationlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Vcollocationsgeolocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vcollocationsgeolocation,VcollocationsgeolocationDto> GetDtoModelField(VcollocationsgeolocationDto dto)
    {
       return dto.Vcollocationsgeolocation;
    }

    protected override VcollocationsgeolocationDto FillEntity(VcollocationsgeolocationDto dto, DtoBase<Vcollocationsgeolocation> field)
    {
        dto.Vcollocationsgeolocation = (VcollocationsgeolocationModelDto)field;

        return dto;
    }
}
