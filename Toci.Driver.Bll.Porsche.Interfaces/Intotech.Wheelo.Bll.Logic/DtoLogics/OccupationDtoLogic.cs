using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;


namespace Intotech.Wheelo.Bll.Logic;


public class OccupationDtoLogic : DtoLogicBase<OccupationModelDto, Occupation, IOccupationLogic, OccupationDto, List<Occupation>, List<OccupationModelDto>>, IOccupationDtoLogic
{
    public OccupationDtoLogic(IOccupationLogic occupationlogic) 
        : base(occupationlogic, 
            (aDto, aModelDto) => { 
                aDto.Occupation = aModelDto;
                return aDto;
            })
    {
    }

    protected override OccupationModelDto GetDtoModelField(OccupationDto dto)
    {
       return dto.Occupation;
    }

    protected override OccupationDto FillEntity(OccupationDto dto, OccupationModelDto  field)
    {
        dto.Occupation = field;

        return dto;
    }    protected override OccupationDto FillEntity(OccupationDto dto, List<OccupationModelDto> field)
    {
        throw new NotImplementedException();
    }
}
