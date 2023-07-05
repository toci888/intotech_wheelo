usignsad

asdasdasd

public class VworktripgengeolocationDtoLogic : DtoLogicBase<VworktripgengeolocationModelDto, Vworktripgengeolocation, IVworktripgengeolocationLogic, VworktripgengeolocationDto, List<Vworktripgengeolocation>, List<VworktripgengeolocationModelDto>>
{
    public VworktripgengeolocationDtoLogic(IVworktripgengeolocationLogic vworktripgengeolocationlogic) 
        : base(vworktripgengeolocationlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Vworktripgengeolocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vworktripgengeolocation,VworktripgengeolocationDto> GetDtoModelField(VworktripgengeolocationDto dto)
    {
       return dto.Vworktripgengeolocation;
    }

    protected override VworktripgengeolocationDto FillEntity(VworktripgengeolocationDto dto, DtoBase<Vworktripgengeolocation> field)
    {
        dto.Vworktripgengeolocation = (VworktripgengeolocationModelDto)field;

        return dto;
    }
}
