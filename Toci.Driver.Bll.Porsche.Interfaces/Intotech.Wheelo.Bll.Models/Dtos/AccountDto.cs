using Intotech.Common.Bll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

namespace Intotech.Wheelo.Bll.Models.Dtos;

public class AccountDto : DtoEntityBase
{
    public AccountModelDto Account { get; set; }
    public AccountroleModelDto AccountRole { get; set; }
    public AccountmodeModelDto AccountMode { get; set; }
}
