usignsad

asdasdasd

public class PasswordstrengthDtoLogic : DtoLogicBase<PasswordstrengthModelDto, Passwordstrength, IPasswordstrengthLogic, PasswordstrengthDto, List<Passwordstrength>, List<PasswordstrengthModelDto>>
{
    public PasswordstrengthDtoLogic(IPasswordstrengthLogic passwordstrengthlogic) 
        : base(passwordstrengthlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Passwordstrength = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Passwordstrength,PasswordstrengthDto> GetDtoModelField(PasswordstrengthDto dto)
    {
       return dto.Passwordstrength;
    }

    protected override PasswordstrengthDto FillEntity(PasswordstrengthDto dto, DtoBase<Passwordstrength> field)
    {
        dto.Passwordstrength = (PasswordstrengthModelDto)field;

        return dto;
    }
}
