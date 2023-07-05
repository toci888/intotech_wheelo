usignsad

asdasdasd

public class UserextradatumDtoLogic : DtoLogicBase<UserextradatumModelDto, Userextradatum, IUserextradatumLogic, UserextradatumDto, List<Userextradatum>, List<UserextradatumModelDto>>
{
    public UserextradatumDtoLogic(IUserextradatumLogic userextradatumlogic) 
        : base(userextradatumlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Userextradatum = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Userextradatum,UserextradatumDto> GetDtoModelField(UserextradatumDto dto)
    {
       return dto.Userextradatum;
    }

    protected override UserextradatumDto FillEntity(UserextradatumDto dto, DtoBase<Userextradatum> field)
    {
        dto.Userextradatum = (UserextradatumModelDto)field;

        return dto;
    }
}
