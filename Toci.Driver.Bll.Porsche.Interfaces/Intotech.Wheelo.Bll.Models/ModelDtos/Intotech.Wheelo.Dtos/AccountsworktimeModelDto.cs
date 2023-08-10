using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;


namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class AccountsworktimeModelDto : DtoCollectionBase<Accountsworktime, AccountsworktimeModelDto, List<Accountsworktime>, List<AccountsworktimeModelDto>>
{
    public int Id { get; set; }
    public int Idaccounts { get; set; }
    public TimeOnly Workstarthour { get; set; }
    public TimeOnly Workendhour { get; set; }
}
