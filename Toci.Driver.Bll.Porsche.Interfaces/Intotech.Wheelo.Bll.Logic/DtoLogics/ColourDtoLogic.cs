usignsad

asdasdasd

public class ColourDtoLogic : DtoLogicBase<ColourModelDto, Colour, IColourLogic, ColourDto, List<Colour>, List<ColourModelDto>>
{
    public ColourDtoLogic(IColourLogic colourlogic) 
        : base(colourlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Colour = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Colour,ColourDto> GetDtoModelField(ColourDto dto)
    {
       return dto.Colour;
    }

    protected override ColourDto FillEntity(ColourDto dto, DtoBase<Colour> field)
    {
        dto.Colour = (ColourModelDto)field;

        return dto;
    }
}
