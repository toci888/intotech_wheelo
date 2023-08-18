using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Common.Bll.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;


public class AccountscarslocationModelDto : DtoModelBase
{
    public int Idaccount { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Streetfrom { get; set; }
    public string Streetto { get; set; }
    public string Cityfrom { get; set; }
    public string Cityto { get; set; }
    public string Registrationplate { get; set; }
    public int Availableseats { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Colour { get; set; }
    public string Rgb { get; set; }
    public int Id { get; set; }
}
