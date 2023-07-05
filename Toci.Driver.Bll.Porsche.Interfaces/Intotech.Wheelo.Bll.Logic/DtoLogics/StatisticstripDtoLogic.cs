usignsad

asdasdasd

public class StatisticstripDtoLogic : DtoLogicBase<StatisticstripModelDto, Statisticstrip, IStatisticstripLogic, StatisticstripDto, List<Statisticstrip>, List<StatisticstripModelDto>>
{
    public StatisticstripDtoLogic(IStatisticstripLogic statisticstriplogic) 
        : base(statisticstriplogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Statisticstrip = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Statisticstrip,StatisticstripDto> GetDtoModelField(StatisticstripDto dto)
    {
       return dto.Statisticstrip;
    }

    protected override StatisticstripDto FillEntity(StatisticstripDto dto, DtoBase<Statisticstrip> field)
    {
        dto.Statisticstrip = (StatisticstripModelDto)field;

        return dto;
    }
}
