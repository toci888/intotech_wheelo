usignsad

asdasdasd

public class FriendDtoLogic : DtoLogicBase<FriendModelDto, Friend, IFriendLogic, FriendDto, List<Friend>, List<FriendModelDto>>
{
    public FriendDtoLogic(IFriendLogic friendlogic) 
        : base(friendlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Friend = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Friend,FriendDto> GetDtoModelField(FriendDto dto)
    {
       return dto.Friend;
    }

    protected override FriendDto FillEntity(FriendDto dto, DtoBase<Friend> field)
    {
        dto.Friend = (FriendModelDto)field;

        return dto;
    }
}
