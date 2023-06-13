using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class AccountDtoLogic : DtoLogicBase<AccountModelDto, Account, AccountLogic, AccountDto>
{
    public AccountDtoLogic(int id) 
        : base(new AccountLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Account = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Account> GetDtoModelField(AccountDto dto)
    {
        return dto.Account;
    }

    protected override AccountDto FillEntity(AccountDto dto, DtoBase<Account> field)
    {
        dto.Account = (AccountModelDto)field;

        return dto;
    }
}