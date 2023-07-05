usignsad

asdasdasd

public class VfriendsuggestionDtoLogic : DtoLogicBase<VfriendsuggestionModelDto, Vfriendsuggestion, IVfriendsuggestionLogic, VfriendsuggestionDto, List<Vfriendsuggestion>, List<VfriendsuggestionModelDto>>
{
    public VfriendsuggestionDtoLogic(IVfriendsuggestionLogic vfriendsuggestionlogic) 
        : base(vfriendsuggestionlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Vfriendsuggestion = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vfriendsuggestion,VfriendsuggestionDto> GetDtoModelField(VfriendsuggestionDto dto)
    {
       return dto.Vfriendsuggestion;
    }

    protected override VfriendsuggestionDto FillEntity(VfriendsuggestionDto dto, DtoBase<Vfriendsuggestion> field)
    {
        dto.Vfriendsuggestion = (VfriendsuggestionModelDto)field;

        return dto;
    }
}
