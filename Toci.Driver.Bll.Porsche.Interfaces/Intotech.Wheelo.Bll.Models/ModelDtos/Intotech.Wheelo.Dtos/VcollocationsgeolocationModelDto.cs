using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class VcollocationsgeolocationModelDto : DtoBase<Vcollocationsgeolocation>
{
    public int Idaccount { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Double Latitudefrom { get; set; }
    public Double Longitudefrom { get; set; }
    public Double Latitudeto { get; set; }
    public Double Longitudeto { get; set; }
    public TimeOnly Fromhour { get; set; }
    public TimeOnly Tohour { get; set; }
    public string Searchid { get; set; }
    public int Driverpassenger { get; set; }
    public string Image { get; set; }
}
