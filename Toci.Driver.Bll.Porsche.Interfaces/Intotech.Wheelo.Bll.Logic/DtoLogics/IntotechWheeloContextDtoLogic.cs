usignsad

asdasdasd

public class IntotechWheeloContextDtoLogic : DtoLogicBase<IntotechWheeloContextModelDto, IntotechWheeloContext, IIntotechWheeloContextLogic, IntotechWheeloContextDto, List<IntotechWheeloContext>, List<IntotechWheeloContextModelDto>>
{
    public IntotechWheeloContextDtoLogic(IIntotechWheeloContextLogic intotechwheelocontextlogic) 
        : base(intotechwheelocontextlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.IntotechWheeloContext = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<IntotechWheeloContext,IntotechWheeloContextDto> GetDtoModelField(IntotechWheeloContextDto dto)
    {
       return dto.IntotechWheeloContext;
    }

    protected override IntotechWheeloContextDto FillEntity(IntotechWheeloContextDto dto, DtoBase<IntotechWheeloContext> field)
    {
        dto.IntotechWheeloContext = (IntotechWheeloContextModelDto)field;

        return dto;
    }
}
