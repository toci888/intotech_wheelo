using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Common.Bll.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.DictionariesModelDto;

public class ColourModelDto : DtoModelBase //DtoCollectionBase<Colour, ColourModelDto, List<Colour>, List<ColourModelDto>>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Rgb { get; set; }
}
