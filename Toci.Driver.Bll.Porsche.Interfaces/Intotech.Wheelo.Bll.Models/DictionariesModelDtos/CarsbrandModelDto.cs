using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models;

public class CarsbrandModelDto : DtoCollectionBase<Carsbrand, CarsbrandModelDto, List<Carsbrand>, List<CarsbrandModelDto>>
{
    public int Id { get; set; }
    public string Brand { get; set; }
}
