using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class StatsproviderModelDto : DtoBase<Statsprovider, StatsproviderModelDto>
{
    public DateOnly Tripdate { get; set; }
    public Int64 Countcars { get; set; }
    public Int64 Countpeople { get; set; }
}
