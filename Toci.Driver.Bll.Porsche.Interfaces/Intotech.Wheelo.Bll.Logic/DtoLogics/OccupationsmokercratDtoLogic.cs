using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;


namespace Intotech.Wheelo.Bll.Logic;


public class OccupationsmokercratDtoLogic : DtoLogicBase<OccupationsmokercratModelDto, Occupationsmokercrat, IOccupationsmokercratLogic, OccupationsmokercratDto, List<Occupationsmokercrat>, List<OccupationsmokercratModelDto>>, IOccupationsmokercratDtoLogic
{
    public OccupationsmokercratDtoLogic(IOccupationsmokercratLogic occupationsmokercratlogic) 
        : base(occupationsmokercratlogic, 
            (aDto, aModelDto) => { 
                aDto.Occupationsmokercrat = aModelDto;
                return aDto;
            })
    {
    }

    protected override OccupationsmokercratModelDto GetDtoModelField(OccupationsmokercratDto dto)
    {
       return dto.Occupationsmokercrat;
    }

    protected override OccupationsmokercratDto FillEntity(OccupationsmokercratDto dto, OccupationsmokercratModelDto  field)
    {
        dto.Occupationsmokercrat = field;

        return dto;
    }    protected override OccupationsmokercratDto FillEntity(OccupationsmokercratDto dto, List<OccupationsmokercratModelDto> field)
    {
        throw new NotImplementedException();
    }
}
