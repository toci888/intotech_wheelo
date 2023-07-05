usignsad

asdasdasd

public class PasswordsstrenghtDtoLogic : DtoLogicBase<PasswordsstrenghtModelDto, Passwordsstrenght, IPasswordsstrenghtLogic, PasswordsstrenghtDto, List<Passwordsstrenght>, List<PasswordsstrenghtModelDto>>
{
    public PasswordsstrenghtDtoLogic(IPasswordsstrenghtLogic passwordsstrenghtlogic) 
        : base(passwordsstrenghtlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Passwordsstrenght = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Passwordsstrenght,PasswordsstrenghtDto> GetDtoModelField(PasswordsstrenghtDto dto)
    {
       return dto.Passwordsstrenght;
    }

    protected override PasswordsstrenghtDto FillEntity(PasswordsstrenghtDto dto, DtoBase<Passwordsstrenght> field)
    {
        dto.Passwordsstrenght = (PasswordsstrenghtModelDto)field;

        return dto;
    }
}
