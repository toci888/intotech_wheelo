using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic;

public class AccountsworktimeDtoLogic : DtoLogicBase<AccountsworktimeModelDto, Accountsworktime, IAccountsworktimeLogic, AccountsworktimeDto, List<Accountsworktime>, List<AccountsworktimeModelDto>>
{
    public AccountsworktimeDtoLogic(IAccountsworktimeLogic accountsworktimelogic) 
        : base(accountsworktimelogic, 
            (aDto, aModelDto) => { 
                aDto.Accountsworktime = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Accountsworktime,AccountsworktimeModelDto> GetDtoModelField(AccountsworktimeDto dto)
    {
       return dto.Accountsworktime;
    }

    protected override AccountsworktimeDto FillEntity(AccountsworktimeDto dto, AccountsworktimeModelDto  field)
    {
        dto.Accountsworktime = field;

        return dto;
    }    protected override AccountsworktimeDto FillEntity(AccountsworktimeDto dto, List<AccountsworktimeModelDto> field)
    {
        throw new NotImplementedException();
    }
}
