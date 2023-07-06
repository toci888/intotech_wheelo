using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;


namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class VacollocationsgeolocationModelDto : DtoCollectionBase<Vacollocationsgeolocation, VacollocationsgeolocationModelDto, List<Vacollocationsgeolocation>, List<VacollocationsgeolocationModelDto>>
{
    public int Idaccount { get; set; }
    public int Accountidcollocated { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Namecollocated { get; set; }
    public string Surnamecollocated { get; set; }
    public Double Latitudefrom { get; set; }
    public Double Longitudefrom { get; set; }
    public Double Latitudeto { get; set; }
    public Double Longitudeto { get; set; }
    public TimeOnly Fromhour { get; set; }
    public TimeOnly Tohour { get; set; }
    public string Searchid { get; set; }
    public int Isdriver { get; set; }
    public string Image { get; set; }
    public int Id { get; set; }
}
