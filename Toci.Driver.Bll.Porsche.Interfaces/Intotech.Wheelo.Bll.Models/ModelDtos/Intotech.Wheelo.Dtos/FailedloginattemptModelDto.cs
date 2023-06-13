using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class FailedloginattemptModelDto : DtoBase<Failedloginattempt>
{
    public int Id { get; set; }
    public int Idaccount { get; set; }
    public int Kind { get; set; }
    public DateTime Createdat { get; set; }
}
