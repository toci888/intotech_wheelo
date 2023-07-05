usignsad

asdasdasd

public class GeographicregionDtoLogic : DtoLogicBase<GeographicregionModelDto, Geographicregion, IGeographicregionLogic, GeographicregionDto, List<Geographicregion>, List<GeographicregionModelDto>>
{
    public GeographicregionDtoLogic(IGeographicregionLogic geographicregionlogic) 
        : base(geographicregionlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Geographicregion = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Geographicregion,GeographicregionDto> GetDtoModelField(GeographicregionDto dto)
    {
       return dto.Geographicregion;
    }

    protected override GeographicregionDto FillEntity(GeographicregionDto dto, DtoBase<Geographicregion> field)
    {
        dto.Geographicregion = (GeographicregionModelDto)field;

        return dto;
    }
}
