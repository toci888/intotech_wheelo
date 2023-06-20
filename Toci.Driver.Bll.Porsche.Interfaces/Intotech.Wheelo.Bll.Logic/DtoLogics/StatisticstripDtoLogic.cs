using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class StatisticstripDtoLogic : DtoLogicBase< StatisticstripModelDto , Statisticstrip , StatisticstripLogic , StatisticstripDto >
{
    public StatisticstripDtoLogic(int id) 
        : base(new StatisticstripLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Statisticstrip = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Statisticstrip> GetDtoModelField(StatisticstripDto dto)
    {
       return dto.Statisticstrip;
    }

    protected override StatisticstripDto FillEntity(StatisticstripDto dto, DtoBase<Statisticstrip> field)
    {
        dto.Statisticstrip = (StatisticstripModelDto)field;

        return dto;
    }
}
