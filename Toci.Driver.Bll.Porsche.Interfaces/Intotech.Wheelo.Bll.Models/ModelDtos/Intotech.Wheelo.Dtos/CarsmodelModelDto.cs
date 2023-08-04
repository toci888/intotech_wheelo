using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Common.Bll.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;


public class CarsmodelModelDto : DtoModelBase
{
    public int Id { get; set; }
    public int Idcarsbrands { get; set; }
    public string Model { get; set; }
}
