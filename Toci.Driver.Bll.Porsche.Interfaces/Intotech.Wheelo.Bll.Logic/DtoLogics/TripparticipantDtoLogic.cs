usignsad

asdasdasd

public class TripparticipantDtoLogic : DtoLogicBase<TripparticipantModelDto, Tripparticipant, ITripparticipantLogic, TripparticipantDto, List<Tripparticipant>, List<TripparticipantModelDto>>
{
    public TripparticipantDtoLogic(ITripparticipantLogic tripparticipantlogic) 
        : base(tripparticipantlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Tripparticipant = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Tripparticipant,TripparticipantDto> GetDtoModelField(TripparticipantDto dto)
    {
       return dto.Tripparticipant;
    }

    protected override TripparticipantDto FillEntity(TripparticipantDto dto, DtoBase<Tripparticipant> field)
    {
        dto.Tripparticipant = (TripparticipantModelDto)field;

        return dto;
    }
}
