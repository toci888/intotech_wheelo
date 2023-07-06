using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;

namespace Intotech.Wheelo.Bll.Logic;

public class VfriendDtoLogic : DtoLogicBase<VfriendModelDto, Vfriend, IVfriendLogic, VfriendDto, List<Vfriend>, List<VfriendModelDto>>, IVfriendDtoLogic
{
    public VfriendDtoLogic(IVfriendLogic vfriendlogic) 
        : base(vfriendlogic, 
            (aDto, aModelDto) => { 
                aDto.Vfriend = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vfriend,VfriendModelDto> GetDtoModelField(VfriendDto dto)
    {
       return dto.Vfriend;
    }

    protected override VfriendDto FillEntity(VfriendDto dto, VfriendModelDto  field)
    {
        dto.Vfriend = field;

        return dto;
    }    protected override VfriendDto FillEntity(VfriendDto dto, List<VfriendModelDto> field)
    {
        throw new NotImplementedException();
    }
}
