using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class VcarownerModelDto : DtoBase<Vcarowner>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Registrationplate { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Availableseats { get; set; }
    public string Colour { get; set; }
    public string Rgb { get; set; }
}
