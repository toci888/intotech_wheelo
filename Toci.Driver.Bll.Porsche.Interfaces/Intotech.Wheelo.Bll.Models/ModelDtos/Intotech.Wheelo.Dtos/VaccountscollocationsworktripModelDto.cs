using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class VaccountscollocationsworktripModelDto : DtoBase<Vaccountscollocationsworktrip>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Suggestedname { get; set; }
    public string Suggestedsurname { get; set; }
    public int Accountid { get; set; }
    public int Suggestedaccountid { get; set; }
    public Decimal Distancefrom { get; set; }
    public Decimal Distanceto { get; set; }
    public Double Latitudefrom { get; set; }
    public Double Longitudefrom { get; set; }
    public Double Latitudeto { get; set; }
    public Double Longitudeto { get; set; }
    public TimeOnly Fromhour { get; set; }
    public TimeOnly Tohour { get; set; }
}
