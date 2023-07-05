usignsad

asdasdasd

public class PushtokenDtoLogic : DtoLogicBase<PushtokenModelDto, Pushtoken, IPushtokenLogic, PushtokenDto, List<Pushtoken>, List<PushtokenModelDto>>
{
    public PushtokenDtoLogic(IPushtokenLogic pushtokenlogic) 
        : base(pushtokenlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Pushtoken = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Pushtoken,PushtokenDto> GetDtoModelField(PushtokenDto dto)
    {
       return dto.Pushtoken;
    }

    protected override PushtokenDto FillEntity(PushtokenDto dto, DtoBase<Pushtoken> field)
    {
        dto.Pushtoken = (PushtokenModelDto)field;

        return dto;
    }
}
