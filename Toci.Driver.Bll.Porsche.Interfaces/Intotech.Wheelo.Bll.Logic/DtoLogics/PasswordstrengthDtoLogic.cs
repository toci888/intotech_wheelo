using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;


namespace Intotech.Wheelo.Bll.Logic;


public class PasswordstrengthDtoLogic : DtoLogicBase<PasswordstrengthModelDto, Passwordstrength, IPasswordstrengthLogic, PasswordstrengthDto, List<Passwordstrength>, List<PasswordstrengthModelDto>>, IPasswordstrengthDtoLogic
{
    public PasswordstrengthDtoLogic(IPasswordstrengthLogic passwordstrengthlogic) 
        : base(passwordstrengthlogic, 
            (aDto, aModelDto) => { 
                aDto.Passwordstrength = aModelDto;
                return aDto;
            })
    {
    }

    protected override PasswordstrengthModelDto GetDtoModelField(PasswordstrengthDto dto)
    {
       return dto.Passwordstrength;
    }

    protected override PasswordstrengthDto FillEntity(PasswordstrengthDto dto, PasswordstrengthModelDto  field)
    {
        dto.Passwordstrength = field;

        return dto;
    }    protected override PasswordstrengthDto FillEntity(PasswordstrengthDto dto, List<PasswordstrengthModelDto> field)
    {
        throw new NotImplementedException();
    }
}
