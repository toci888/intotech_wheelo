usignsad

asdasdasd

public class OccupationDtoLogic : DtoLogicBase<OccupationModelDto, Occupation, IOccupationLogic, OccupationDto, List<Occupation>, List<OccupationModelDto>>
{
    public OccupationDtoLogic(IOccupationLogic occupationlogic) 
        : base(occupationlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Occupation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Occupation,OccupationDto> GetDtoModelField(OccupationDto dto)
    {
       return dto.Occupation;
    }

    protected override OccupationDto FillEntity(OccupationDto dto, DtoBase<Occupation> field)
    {
        dto.Occupation = (OccupationModelDto)field;

        return dto;
    }
}
