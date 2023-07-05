usignsad

asdasdasd

public class AccountmodeDtoLogic : DtoLogicBase<AccountmodeModelDto, Accountmode, IAccountmodeLogic, AccountmodeDto, List<Accountmode>, List<AccountmodeModelDto>>
{
    public AccountmodeDtoLogic(IAccountmodeLogic accountmodelogic) 
        : base(accountmodelogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Accountmode = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Accountmode,AccountmodeDto> GetDtoModelField(AccountmodeDto dto)
    {
       return dto.Accountmode;
    }

    protected override AccountmodeDto FillEntity(AccountmodeDto dto, DtoBase<Accountmode> field)
    {
        dto.Accountmode = (AccountmodeModelDto)field;

        return dto;
    }
}
