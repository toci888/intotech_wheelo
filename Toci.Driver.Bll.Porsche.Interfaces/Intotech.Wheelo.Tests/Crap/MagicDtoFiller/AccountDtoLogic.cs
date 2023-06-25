using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Tests.Crap.MagicDtoFiller.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Crap.MagicDtoFiller;

public class AccountDtoLogic : DtoLogicBase<AccountModelDto, Account, AccountLogic, AccountDto, List<Account>, List<AccountModelDto>>
{
    public AccountDtoLogic(int accountId) : base(new AccountLogic(), 
        null)
    {
    }

    protected override DtoBase<Account, AccountModelDto> GetDtoModelField(AccountDto dto)
    {
        return dto.Account;
    }

    protected override AccountDto FillEntity(AccountDto dto, AccountModelDto field)
    {
        dto.Account = field.MapDtoToDto();

        return dto;
    }

    protected override AccountDto FillEntity(AccountDto dto, List<AccountModelDto> field)
    {
        throw new NotImplementedException();
    }
}