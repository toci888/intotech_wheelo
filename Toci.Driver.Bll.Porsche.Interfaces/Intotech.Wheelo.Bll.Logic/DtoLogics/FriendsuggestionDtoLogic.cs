using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;

namespace Intotech.Wheelo.Bll.Logic;

public class FriendsuggestionDtoLogic : DtoLogicBase<FriendsuggestionModelDto, Friendsuggestion, IFriendsuggestionLogic, FriendsuggestionDto, List<Friendsuggestion>, List<FriendsuggestionModelDto>>, IFriendsuggestionDtoLogic
{
    public FriendsuggestionDtoLogic(IFriendsuggestionLogic friendsuggestionlogic) 
        : base(friendsuggestionlogic, 
            (aDto, aModelDto) => { 
                aDto.Friendsuggestion = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Friendsuggestion,FriendsuggestionModelDto> GetDtoModelField(FriendsuggestionDto dto)
    {
       return dto.Friendsuggestion;
    }

    protected override FriendsuggestionDto FillEntity(FriendsuggestionDto dto, FriendsuggestionModelDto  field)
    {
        dto.Friendsuggestion = field;

        return dto;
    }    protected override FriendsuggestionDto FillEntity(FriendsuggestionDto dto, List<FriendsuggestionModelDto> field)
    {
        throw new NotImplementedException();
    }
}
