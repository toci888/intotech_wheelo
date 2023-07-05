
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic;

public class AccountDtoLogic : DtoLogicBase<AccountModelDto, Account, IAccountLogic, AccountDto, List<Account>, List<AccountModelDto>>
{
    public AccountDtoLogic(IAccountLogic accountlogic) 
        : base(accountlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Account = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Account,AccountDto> GetDtoModelField(AccountDto dto)
    {
       return dto.Account;
    }

    protected override AccountDto FillEntity(AccountDto dto, DtoBase<Account> field)
    {
        dto.Account = (AccountModelDto)field;

        return dto;
    }
}
