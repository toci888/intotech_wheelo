using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class CarModelDto : DtoBase<Car, CarModelDto>
{
    public int Id { get; set; }
    public int Idaccounts { get; set; }
    public int Idcarsbrands { get; set; }
    public int Idcarsmodels { get; set; }
    public int Idcolours { get; set; }
    public string Registrationplate { get; set; }
    public int Availableseats { get; set; }
    public DateTime Createdat { get; set; }
}
