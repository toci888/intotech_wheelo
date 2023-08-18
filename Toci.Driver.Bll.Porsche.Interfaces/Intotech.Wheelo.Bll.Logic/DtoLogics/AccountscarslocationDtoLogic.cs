using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;


namespace Intotech.Wheelo.Bll.Logic;


public class AccountscarslocationDtoLogic : DtoLogicBase<AccountscarslocationModelDto, Accountscarslocation, IAccountscarslocationLogic, AccountscarslocationDto, List<Accountscarslocation>, List<AccountscarslocationModelDto>>, IAccountscarslocationDtoLogic
{
    public AccountscarslocationDtoLogic(IAccountscarslocationLogic accountscarslocationlogic) 
        : base(accountscarslocationlogic, 
            (aDto, aModelDto) => { 
                aDto.Accountscarslocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override AccountscarslocationModelDto GetDtoModelField(AccountscarslocationDto dto)
    {
       return dto.Accountscarslocation;
    }

    protected override AccountscarslocationDto FillEntity(AccountscarslocationDto dto, AccountscarslocationModelDto  field)
    {
        dto.Accountscarslocation = field;

        return dto;
    }    protected override AccountscarslocationDto FillEntity(AccountscarslocationDto dto, List<AccountscarslocationModelDto> field)
    {
        throw new NotImplementedException();
    }
}
