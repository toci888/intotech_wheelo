using Intotech.Common.Bll;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

namespace Intotech.Wheelo.Bll.Models.Dtos;

public class AccountDto : DtoBase
{
    public AccountModelDto Account { get; set; }
    public AccountroleModelDto AccountRole { get; set; }
    public AccountmodeModelDto AccountMode { get; set; }
}
