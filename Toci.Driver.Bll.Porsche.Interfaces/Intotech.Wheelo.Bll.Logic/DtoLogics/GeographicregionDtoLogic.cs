using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class GeographicregionDtoLogic : DtoLogicBase< GeographicregionModelDto , Geographicregion , GeographicregionLogic , GeographicregionDto >
{
    public GeographicregionDtoLogic(int id) 
        : base(new GeographicregionLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Geographicregion = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Geographicregion> GetDtoModelField(GeographicregionDto dto)
    {
       return dto.Geographicregion;
    }

    protected override GeographicregionDto FillEntity(GeographicregionDto dto, DtoBase<Geographicregion> field)
    {
        dto.Geographicregion = (GeographicregionModelDto)field;

        return dto;
    }
}
