using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;

namespace Intotech.Wheelo.Bll.Logic;

public class GeographicregionDtoLogic : DtoLogicBase<GeographicregionModelDto, Geographicregion, IGeographicregionLogic, GeographicregionDto, List<Geographicregion>, List<GeographicregionModelDto>>, IGeographicregionDtoLogic
{
    public GeographicregionDtoLogic(IGeographicregionLogic geographicregionlogic) 
        : base(geographicregionlogic, 
            (aDto, aModelDto) => { 
                aDto.Geographicregion = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Geographicregion,GeographicregionModelDto> GetDtoModelField(GeographicregionDto dto)
    {
       return dto.Geographicregion;
    }

    protected override GeographicregionDto FillEntity(GeographicregionDto dto, GeographicregionModelDto  field)
    {
        dto.Geographicregion = field;

        return dto;
    }    protected override GeographicregionDto FillEntity(GeographicregionDto dto, List<GeographicregionModelDto> field)
    {
        throw new NotImplementedException();
    }
}
