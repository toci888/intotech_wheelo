usignsad

asdasdasd

public class AccountscollocationDtoLogic : DtoLogicBase<AccountscollocationModelDto, Accountscollocation, IAccountscollocationLogic, AccountscollocationDto, List<Accountscollocation>, List<AccountscollocationModelDto>>
{
    public AccountscollocationDtoLogic(IAccountscollocationLogic accountscollocationlogic) 
        : base(accountscollocationlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Accountscollocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Accountscollocation,AccountscollocationDto> GetDtoModelField(AccountscollocationDto dto)
    {
       return dto.Accountscollocation;
    }

    protected override AccountscollocationDto FillEntity(AccountscollocationDto dto, DtoBase<Accountscollocation> field)
    {
        dto.Accountscollocation = (AccountscollocationModelDto)field;

        return dto;
    }
}
