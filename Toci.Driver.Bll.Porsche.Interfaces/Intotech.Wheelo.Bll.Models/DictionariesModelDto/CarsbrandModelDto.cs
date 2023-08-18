using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Common.Bll.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.DictionariesModelDto;

public class CarsbrandModelDto : DtoModelBase//DtoCollectionBase<Carsbrand, CarsbrandModelDto, List<Carsbrand>, List<CarsbrandModelDto>>
{
    public int Id { get; set; }
    public string Brand { get; set; }
}
