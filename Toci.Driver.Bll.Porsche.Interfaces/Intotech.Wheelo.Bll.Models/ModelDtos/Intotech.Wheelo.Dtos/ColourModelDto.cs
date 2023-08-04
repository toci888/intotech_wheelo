using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Common.Bll.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;


public class ColourModelDto : DtoModelBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Rgb { get; set; }
}
