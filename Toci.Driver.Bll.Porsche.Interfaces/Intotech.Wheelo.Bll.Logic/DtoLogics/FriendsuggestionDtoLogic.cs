usignsad

asdasdasd

public class FriendsuggestionDtoLogic : DtoLogicBase<FriendsuggestionModelDto, Friendsuggestion, IFriendsuggestionLogic, FriendsuggestionDto, List<Friendsuggestion>, List<FriendsuggestionModelDto>>
{
    public FriendsuggestionDtoLogic(IFriendsuggestionLogic friendsuggestionlogic) 
        : base(friendsuggestionlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Friendsuggestion = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Friendsuggestion,FriendsuggestionDto> GetDtoModelField(FriendsuggestionDto dto)
    {
       return dto.Friendsuggestion;
    }

    protected override FriendsuggestionDto FillEntity(FriendsuggestionDto dto, DtoBase<Friendsuggestion> field)
    {
        dto.Friendsuggestion = (FriendsuggestionModelDto)field;

        return dto;
    }
}
