using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;

namespace Intotech.Wheelo.Bll.Logic;

public class UserextradatumDtoLogic : DtoLogicBase<UserextradatumModelDto, Userextradatum, IUserextradatumLogic, UserextradatumDto, List<Userextradatum>, List<UserextradatumModelDto>>, IUserextradatumDtoLogic
{
    public UserextradatumDtoLogic(IUserextradatumLogic userextradatumlogic) 
        : base(userextradatumlogic, 
            (aDto, aModelDto) => { 
                aDto.Userextradatum = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Userextradatum,UserextradatumModelDto> GetDtoModelField(UserextradatumDto dto)
    {
       return dto.Userextradatum;
    }

    protected override UserextradatumDto FillEntity(UserextradatumDto dto, UserextradatumModelDto  field)
    {
        dto.Userextradatum = field;

        return dto;
    }    protected override UserextradatumDto FillEntity(UserextradatumDto dto, List<UserextradatumModelDto> field)
    {
        throw new NotImplementedException();
    }
}
