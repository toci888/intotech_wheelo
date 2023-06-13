using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Wheelo.Bll.Logic.DtoLogics;
using Intotech.Wheelo.Bll.Models.Dtos;

namespace Intotech.Wheelo.Bll.Logic.Managers;

public class AccountDtoLogicManager : DtoLogicManager<AccountDto>
{
    public AccountDtoLogicManager(int accountId)
    {
        AddDtoLogic(new AccountDtoLogic(accountId));
        AddDtoLogic(new AccountmetadatumDtoLogic(accountId));
    }
}