using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class GeographicregionModelDto : DtoBase<Geographicregion>
{
    public int Id { get; set; }
    public int Idparent { get; set; }
    public int Idshit { get; set; }
    public string Name { get; set; }
    public int Nestlevel { get; set; }
}
