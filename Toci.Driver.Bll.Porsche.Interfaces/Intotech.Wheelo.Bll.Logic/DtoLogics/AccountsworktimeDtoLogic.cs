usignsad

asdasdasd

public class AccountsworktimeDtoLogic : DtoLogicBase<AccountsworktimeModelDto, Accountsworktime, IAccountsworktimeLogic, AccountsworktimeDto, List<Accountsworktime>, List<AccountsworktimeModelDto>>
{
    public AccountsworktimeDtoLogic(IAccountsworktimeLogic accountsworktimelogic) 
        : base(accountsworktimelogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Accountsworktime = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Accountsworktime,AccountsworktimeDto> GetDtoModelField(AccountsworktimeDto dto)
    {
       return dto.Accountsworktime;
    }

    protected override AccountsworktimeDto FillEntity(AccountsworktimeDto dto, DtoBase<Accountsworktime> field)
    {
        dto.Accountsworktime = (AccountsworktimeModelDto)field;

        return dto;
    }
}
