using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic;

public class StatisticstripDtoLogic : DtoLogicBase<StatisticstripModelDto, Statisticstrip, IStatisticstripLogic, StatisticstripDto, List<Statisticstrip>, List<StatisticstripModelDto>>
{
    public StatisticstripDtoLogic(IStatisticstripLogic statisticstriplogic) 
        : base(statisticstriplogic, 
            (aDto, aModelDto) => { 
                aDto.Statisticstrip = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Statisticstrip,StatisticstripModelDto> GetDtoModelField(StatisticstripDto dto)
    {
       return dto.Statisticstrip;
    }

    protected override StatisticstripDto FillEntity(StatisticstripDto dto, StatisticstripModelDto  field)
    {
        dto.Statisticstrip = field;

        return dto;
    }    protected override StatisticstripDto FillEntity(StatisticstripDto dto, List<StatisticstripModelDto> field)
    {
        throw new NotImplementedException();
    }
}
