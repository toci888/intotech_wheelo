using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;


namespace Intotech.Wheelo.Bll.Logic;


public class PasswordsstrenghtDtoLogic : DtoLogicBase<PasswordsstrenghtModelDto, Passwordsstrenght, IPasswordsstrenghtLogic, PasswordsstrenghtDto, List<Passwordsstrenght>, List<PasswordsstrenghtModelDto>>, IPasswordsstrenghtDtoLogic
{
    public PasswordsstrenghtDtoLogic(IPasswordsstrenghtLogic passwordsstrenghtlogic) 
        : base(passwordsstrenghtlogic, 
            (aDto, aModelDto) => { 
                aDto.Passwordsstrenght = aModelDto;
                return aDto;
            })
    {
    }

    protected override PasswordsstrenghtModelDto GetDtoModelField(PasswordsstrenghtDto dto)
    {
       return dto.Passwordsstrenght;
    }

    protected override PasswordsstrenghtDto FillEntity(PasswordsstrenghtDto dto, PasswordsstrenghtModelDto  field)
    {
        dto.Passwordsstrenght = field;

        return dto;
    }    protected override PasswordsstrenghtDto FillEntity(PasswordsstrenghtDto dto, List<PasswordsstrenghtModelDto> field)
    {
        throw new NotImplementedException();
    }
}
