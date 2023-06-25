using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class UserextradatumDtoLogic : DtoLogicBase< UserextradatumModelDto , Userextradatum , UserextradatumLogic , UserextradatumDto >
{
    public UserextradatumDtoLogic(int id) 
        : base(new UserextradatumLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Userextradatum = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Userextradatum> GetDtoModelField(UserextradatumDto dto)
    {
       return dto.Userextradatum;
    }

    protected override UserextradatumDto FillEntity(UserextradatumDto dto, DtoBase<Userextradatum> field)
    {
        dto.Userextradatum = (UserextradatumModelDto)field;

        return dto;
    }
}
