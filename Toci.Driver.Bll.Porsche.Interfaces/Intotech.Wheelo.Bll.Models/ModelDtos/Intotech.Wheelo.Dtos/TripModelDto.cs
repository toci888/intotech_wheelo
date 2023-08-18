using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Common.Bll.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;


public class TripModelDto : DtoModelBase
{
    public int Id { get; set; }
    public int Idinitiatoraccount { get; set; }
    public int Idworktrip { get; set; }
    public DateOnly Tripdate { get; set; }
    public Boolean Iscurrent { get; set; }
    public TimeOnly Fromhour { get; set; }
    public TimeOnly Tohour { get; set; }
    public string Summary { get; set; }
    public DateTime Createdat { get; set; }
    public int Leftseats { get; set; }
}
