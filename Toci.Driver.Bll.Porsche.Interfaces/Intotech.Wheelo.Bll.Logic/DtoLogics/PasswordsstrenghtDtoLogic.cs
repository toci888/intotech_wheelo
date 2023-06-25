using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class PasswordsstrenghtDtoLogic : DtoLogicBase< PasswordsstrenghtModelDto , Passwordsstrenght , PasswordsstrenghtLogic , PasswordsstrenghtDto >
{
    public PasswordsstrenghtDtoLogic(int id) 
        : base(new PasswordsstrenghtLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Passwordsstrenght = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Passwordsstrenght> GetDtoModelField(PasswordsstrenghtDto dto)
    {
       return dto.Passwordsstrenght;
    }

    protected override PasswordsstrenghtDto FillEntity(PasswordsstrenghtDto dto, DtoBase<Passwordsstrenght> field)
    {
        dto.Passwordsstrenght = (PasswordsstrenghtModelDto)field;

        return dto;
    }
}
