using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class VworktripgengeolocationModelDto : DtoBase<Vworktripgengeolocation, VworktripgengeolocationModelDto>
{
    public int Idaccount { get; set; }
    public int Accountidcollocated { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Double Latitudefrom { get; set; }
    public Double Longitudefrom { get; set; }
    public Double Latitudeto { get; set; }
    public Double Longitudeto { get; set; }
    public TimeOnly Fromhour { get; set; }
    public TimeOnly Tohour { get; set; }
    public string Searchid { get; set; }
}
