using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Wheelo.Bll.Logic.DtoLogics;
using Intotech.Wheelo.Bll.Logic.Interfaces.Managers;
using Intotech.Wheelo.Bll.Models.Dtos;

namespace Intotech.Wheelo.Bll.Logic.Managers;

public class AccountDtoLogicManager : DtoLogicManager<AccountDto>, IAccountDtoLogicManager
{
    public AccountDtoLogicManager(int accountId)
    {
        AccountmetadatumDtoLogic accountmetadatumDtoLogic = new AccountmetadatumDtoLogic();
        accountmetadatumDtoLogic.SetSelectFilter(m => m.Idaccount == accountId);

        AddDtoLogic(new AccountDtoLogic(accountId));
        AddDtoLogic(accountmetadatumDtoLogic);
    }
}