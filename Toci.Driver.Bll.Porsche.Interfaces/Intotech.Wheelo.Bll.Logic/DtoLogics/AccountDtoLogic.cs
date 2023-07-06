using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;

namespace Intotech.Wheelo.Bll.Logic;

public class AccountDtoLogic : DtoLogicBase<AccountModelDto, Account, IAccountLogic, AccountDto, List<Account>, List<AccountModelDto>>, IAccountDtoLogic
{
    public AccountDtoLogic(IAccountLogic accountlogic) 
        : base(accountlogic, 
            (aDto, aModelDto) => { 
                aDto.Account = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Account,AccountModelDto> GetDtoModelField(AccountDto dto)
    {
       return dto.Account;
    }

    protected override AccountDto FillEntity(AccountDto dto, AccountModelDto  field)
    {
        dto.Account = field;

        return dto;
    }    protected override AccountDto FillEntity(AccountDto dto, List<AccountModelDto> field)
    {
        throw new NotImplementedException();
    }
}
