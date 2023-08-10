using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;

namespace Intotech.Wheelo.Bll.Logic;

public class FriendDtoLogic : DtoLogicBase<FriendModelDto, Friend, IFriendLogic, FriendDto, List<Friend>, List<FriendModelDto>>, IFriendDtoLogic
{
    public FriendDtoLogic(IFriendLogic friendlogic) 
        : base(friendlogic, 
            (aDto, aModelDto) => { 
                aDto.Friend = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Friend,FriendModelDto> GetDtoModelField(FriendDto dto)
    {
       return dto.Friend;
    }

    protected override FriendDto FillEntity(FriendDto dto, FriendModelDto  field)
    {
        dto.Friend = field;

        return dto;
    }    protected override FriendDto FillEntity(FriendDto dto, List<FriendModelDto> field)
    {
        throw new NotImplementedException();
    }
}
