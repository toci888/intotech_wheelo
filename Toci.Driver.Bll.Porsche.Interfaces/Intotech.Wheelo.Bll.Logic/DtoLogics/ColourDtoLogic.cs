using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;


namespace Intotech.Wheelo.Bll.Logic;


public class ColourDtoLogic : DtoLogicBase<ColourModelDto, Colour, IColourLogic, ColourDto, List<Colour>, List<ColourModelDto>>, IColourDtoLogic
{
    public ColourDtoLogic(IColourLogic colourlogic) 
        : base(colourlogic, 
            (aDto, aModelDto) => { 
                aDto.Colour = aModelDto;
                return aDto;
            })
    {
    }

    protected override ColourModelDto GetDtoModelField(ColourDto dto)
    {
       return dto.Colour;
    }

    protected override ColourDto FillEntity(ColourDto dto, ColourModelDto  field)
    {
        dto.Colour = field;

        return dto;
    }    protected override ColourDto FillEntity(ColourDto dto, List<ColourModelDto> field)
    {
        throw new NotImplementedException();
    }
}
