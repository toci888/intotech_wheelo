usignsad

asdasdasd

public class OccupationsmokercratDtoLogic : DtoLogicBase<OccupationsmokercratModelDto, Occupationsmokercrat, IOccupationsmokercratLogic, OccupationsmokercratDto, List<Occupationsmokercrat>, List<OccupationsmokercratModelDto>>
{
    public OccupationsmokercratDtoLogic(IOccupationsmokercratLogic occupationsmokercratlogic) 
        : base(occupationsmokercratlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Occupationsmokercrat = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Occupationsmokercrat,OccupationsmokercratDto> GetDtoModelField(OccupationsmokercratDto dto)
    {
       return dto.Occupationsmokercrat;
    }

    protected override OccupationsmokercratDto FillEntity(OccupationsmokercratDto dto, DtoBase<Occupationsmokercrat> field)
    {
        dto.Occupationsmokercrat = (OccupationsmokercratModelDto)field;

        return dto;
    }
}
