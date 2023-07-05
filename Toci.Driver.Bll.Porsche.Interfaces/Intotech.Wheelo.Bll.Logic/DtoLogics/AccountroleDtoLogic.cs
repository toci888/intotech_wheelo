usignsad

asdasdasd

public class AccountroleDtoLogic : DtoLogicBase<AccountroleModelDto, Accountrole, IAccountroleLogic, AccountroleDto, List<Accountrole>, List<AccountroleModelDto>>
{
    public AccountroleDtoLogic(IAccountroleLogic accountrolelogic) 
        : base(accountrolelogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Accountrole = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Accountrole,AccountroleDto> GetDtoModelField(AccountroleDto dto)
    {
       return dto.Accountrole;
    }

    protected override AccountroleDto FillEntity(AccountroleDto dto, DtoBase<Accountrole> field)
    {
        dto.Accountrole = (AccountroleModelDto)field;

        return dto;
    }
}
