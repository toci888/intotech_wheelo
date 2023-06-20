using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class AccountslocationModelDto : DtoBase<Accountslocation, AccountslocationModelDto>
{
    public int Id { get; set; }
    public int Idaccounts { get; set; }
    public Decimal Latitudefrom { get; set; }
    public Decimal Longitudefrom { get; set; }
    public Decimal Latitudeto { get; set; }
    public Decimal Longitudeto { get; set; }
    public string Streetfrom { get; set; }
    public string Streetto { get; set; }
    public string Cityfrom { get; set; }
    public string Cityto { get; set; }
    public DateTime Createdat { get; set; }
}
