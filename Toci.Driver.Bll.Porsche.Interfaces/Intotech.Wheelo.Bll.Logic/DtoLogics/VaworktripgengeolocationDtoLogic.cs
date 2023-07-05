usignsad

asdasdasd

public class VaworktripgengeolocationDtoLogic : DtoLogicBase<VaworktripgengeolocationModelDto, Vaworktripgengeolocation, IVaworktripgengeolocationLogic, VaworktripgengeolocationDto, List<Vaworktripgengeolocation>, List<VaworktripgengeolocationModelDto>>
{
    public VaworktripgengeolocationDtoLogic(IVaworktripgengeolocationLogic vaworktripgengeolocationlogic) 
        : base(vaworktripgengeolocationlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Vaworktripgengeolocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vaworktripgengeolocation,VaworktripgengeolocationDto> GetDtoModelField(VaworktripgengeolocationDto dto)
    {
       return dto.Vaworktripgengeolocation;
    }

    protected override VaworktripgengeolocationDto FillEntity(VaworktripgengeolocationDto dto, DtoBase<Vaworktripgengeolocation> field)
    {
        dto.Vaworktripgengeolocation = (VaworktripgengeolocationModelDto)field;

        return dto;
    }
}
