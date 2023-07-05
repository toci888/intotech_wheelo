usignsad

asdasdasd

public class AccountmetadatumDtoLogic : DtoLogicBase<AccountmetadatumModelDto, Accountmetadatum, IAccountmetadatumLogic, AccountmetadatumDto, List<Accountmetadatum>, List<AccountmetadatumModelDto>>
{
    public AccountmetadatumDtoLogic(IAccountmetadatumLogic accountmetadatumlogic) 
        : base(accountmetadatumlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Accountmetadatum = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Accountmetadatum,AccountmetadatumDto> GetDtoModelField(AccountmetadatumDto dto)
    {
       return dto.Accountmetadatum;
    }

    protected override AccountmetadatumDto FillEntity(AccountmetadatumDto dto, DtoBase<Accountmetadatum> field)
    {
        dto.Accountmetadatum = (AccountmetadatumModelDto)field;

        return dto;
    }
}
