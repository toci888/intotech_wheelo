usignsad

asdasdasd

public class AccountslocationDtoLogic : DtoLogicBase<AccountslocationModelDto, Accountslocation, IAccountslocationLogic, AccountslocationDto, List<Accountslocation>, List<AccountslocationModelDto>>
{
    public AccountslocationDtoLogic(IAccountslocationLogic accountslocationlogic) 
        : base(accountslocationlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Accountslocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Accountslocation,AccountslocationDto> GetDtoModelField(AccountslocationDto dto)
    {
       return dto.Accountslocation;
    }

    protected override AccountslocationDto FillEntity(AccountslocationDto dto, DtoBase<Accountslocation> field)
    {
        dto.Accountslocation = (AccountslocationModelDto)field;

        return dto;
    }
}
