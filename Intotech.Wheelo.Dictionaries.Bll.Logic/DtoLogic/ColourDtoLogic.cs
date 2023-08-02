

namespace Intotech.Wheelo.Dictionaries.Bll.Logic;

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
