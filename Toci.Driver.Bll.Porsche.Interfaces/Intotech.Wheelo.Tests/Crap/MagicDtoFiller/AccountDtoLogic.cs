using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Tests.Crap.MagicDtoFiller.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Crap.MagicDtoFiller;

public class AccountDtoLogic : DtoLogicBase<Account, AccountLogic, AccountDto>
{
    public AccountDtoLogic(int accountId) : base(new AccountLogic(), 
        m => m.Id == accountId, 
        null,null)
    {
    }

    protected override AccountDto FillEntity(AccountDto dto, Account field)
    {
        dto.Account = field;

        return dto;
    }
}