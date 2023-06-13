using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class VfriendModelDto : DtoBase<Vfriend>
{
    public int Idaccount { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Friendname { get; set; }
    public string Friendsurname { get; set; }
    public int Friendidaccount { get; set; }
    public int Method { get; set; }
    public Double Latitudefrom { get; set; }
    public Double Longitudefrom { get; set; }
    public Double Latitudeto { get; set; }
    public Double Longitudeto { get; set; }
    public TimeOnly Fromhour { get; set; }
    public TimeOnly Tohour { get; set; }
    public string Searchid { get; set; }
    public int Driverpassenger { get; set; }
}
