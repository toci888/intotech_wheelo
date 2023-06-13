using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class ColourModelDto : DtoBase<Colour>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Rgb { get; set; }
}
