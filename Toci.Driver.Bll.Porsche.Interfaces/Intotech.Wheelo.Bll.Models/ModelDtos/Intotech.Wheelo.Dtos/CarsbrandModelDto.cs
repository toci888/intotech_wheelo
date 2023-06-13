using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class CarsbrandModelDto : DtoBase<Carsbrand>
{
    public int Id { get; set; }
    public string Brand { get; set; }
}
