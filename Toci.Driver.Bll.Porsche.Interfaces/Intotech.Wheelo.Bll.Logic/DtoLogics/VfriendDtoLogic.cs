usignsad

asdasdasd

public class VfriendDtoLogic : DtoLogicBase<VfriendModelDto, Vfriend, IVfriendLogic, VfriendDto, List<Vfriend>, List<VfriendModelDto>>
{
    public VfriendDtoLogic(IVfriendLogic vfriendlogic) 
        : base(vfriendlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Vfriend = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vfriend,VfriendDto> GetDtoModelField(VfriendDto dto)
    {
       return dto.Vfriend;
    }

    protected override VfriendDto FillEntity(VfriendDto dto, DtoBase<Vfriend> field)
    {
        dto.Vfriend = (VfriendModelDto)field;

        return dto;
    }
}
