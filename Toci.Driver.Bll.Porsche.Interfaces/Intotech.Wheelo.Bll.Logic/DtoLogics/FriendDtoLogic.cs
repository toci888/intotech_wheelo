using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class FriendDtoLogic : DtoLogicBase<FriendModelDto, Friend, IFriendLogic, FriendDto>
{
    public FriendDtoLogic(IFriendLogic friendLogic) 
        : base( friendLogic , m => m.Id == Id, // do wymyślenia 
            (aDto, aModelDto) => { 
                aDto.Friend = aModelDto;
                return aDto;
            }) 
    {
    }

    protected override DtoBase<Friend> GetDtoModelField(FriendDto dto)
    {
       return dto.Friend;
    }

    protected override FriendDto FillEntity(FriendDto dto, DtoBase<Friend> field)
    {
        dto.Friend = (FriendModelDto)field;

        return dto;
    }
}
