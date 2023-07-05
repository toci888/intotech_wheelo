usignsad

asdasdasd

public class AccountscarslocationDtoLogic : DtoLogicBase<AccountscarslocationModelDto, Accountscarslocation, IAccountscarslocationLogic, AccountscarslocationDto, List<Accountscarslocation>, List<AccountscarslocationModelDto>>
{
    public AccountscarslocationDtoLogic(IAccountscarslocationLogic accountscarslocationlogic) 
        : base(accountscarslocationlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Accountscarslocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Accountscarslocation,AccountscarslocationDto> GetDtoModelField(AccountscarslocationDto dto)
    {
       return dto.Accountscarslocation;
    }

    protected override AccountscarslocationDto FillEntity(AccountscarslocationDto dto, DtoBase<Accountscarslocation> field)
    {
        dto.Accountscarslocation = (AccountscarslocationModelDto)field;

        return dto;
    }
}
