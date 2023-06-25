using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class PasswordstrengthDtoLogic : DtoLogicBase< PasswordstrengthModelDto , Passwordstrength , PasswordstrengthLogic , PasswordstrengthDto >
{
    public PasswordstrengthDtoLogic(int id) 
        : base(new PasswordstrengthLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Passwordstrength = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Passwordstrength> GetDtoModelField(PasswordstrengthDto dto)
    {
       return dto.Passwordstrength;
    }

    protected override PasswordstrengthDto FillEntity(PasswordstrengthDto dto, DtoBase<Passwordstrength> field)
    {
        dto.Passwordstrength = (PasswordstrengthModelDto)field;

        return dto;
    }
}
