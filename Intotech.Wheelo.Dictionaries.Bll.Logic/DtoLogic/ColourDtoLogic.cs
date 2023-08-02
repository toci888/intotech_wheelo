using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Wheelo.Bll.Models.DictionariesModelDto;
using Intotech.Wheelo.Bll.Models.DictionariesDto;
using Intotech.Wheelo.Dictionaries.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Dictionaries.Database.Persistence.Models;
using Intotech.Wheelo.Dictionaries.Bll.Logic.Interfaces.IDtoLogic;
using Intotech.Common.Bll.ChorDtoBll.Dto;

namespace Intotech.Wheelo.Dictionaries.Bll.Logic.DtoLogic;

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

    protected override DtoBase<Colour,ColourModelDto> GetDtoModelField(ColourDto dto)
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
