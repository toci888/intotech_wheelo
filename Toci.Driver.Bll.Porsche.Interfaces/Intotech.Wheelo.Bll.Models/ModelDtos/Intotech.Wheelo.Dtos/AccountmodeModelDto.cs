using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class AccountmodeModelDto : DtoBase<Accountmode>
{
    public int Idaccount { get; set; }
    public int Mode { get; set; }
}
