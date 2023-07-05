usignsad

asdasdasd

public class StatsproviderDtoLogic : DtoLogicBase<StatsproviderModelDto, Statsprovider, IStatsproviderLogic, StatsproviderDto, List<Statsprovider>, List<StatsproviderModelDto>>
{
    public StatsproviderDtoLogic(IStatsproviderLogic statsproviderlogic) 
        : base(statsproviderlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Statsprovider = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Statsprovider,StatsproviderDto> GetDtoModelField(StatsproviderDto dto)
    {
       return dto.Statsprovider;
    }

    protected override StatsproviderDto FillEntity(StatsproviderDto dto, DtoBase<Statsprovider> field)
    {
        dto.Statsprovider = (StatsproviderModelDto)field;

        return dto;
    }
}
