using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class OccupationsmokercratModelDto : DtoBase<Occupationsmokercrat>
{
    public int Id { get; set; }
    public int Idaccount { get; set; }
    public int Idoccupation { get; set; }
    public Boolean Issmoker { get; set; }
    public DateTime Createdat { get; set; }
}
