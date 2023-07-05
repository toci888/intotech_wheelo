usignsad

asdasdasd

public class VacollocationsgeolocationDtoLogic : DtoLogicBase<VacollocationsgeolocationModelDto, Vacollocationsgeolocation, IVacollocationsgeolocationLogic, VacollocationsgeolocationDto, List<Vacollocationsgeolocation>, List<VacollocationsgeolocationModelDto>>
{
    public VacollocationsgeolocationDtoLogic(IVacollocationsgeolocationLogic vacollocationsgeolocationlogic) 
        : base(vacollocationsgeolocationlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Vacollocationsgeolocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vacollocationsgeolocation,VacollocationsgeolocationDto> GetDtoModelField(VacollocationsgeolocationDto dto)
    {
       return dto.Vacollocationsgeolocation;
    }

    protected override VacollocationsgeolocationDto FillEntity(VacollocationsgeolocationDto dto, DtoBase<Vacollocationsgeolocation> field)
    {
        dto.Vacollocationsgeolocation = (VacollocationsgeolocationModelDto)field;

        return dto;
    }
}
