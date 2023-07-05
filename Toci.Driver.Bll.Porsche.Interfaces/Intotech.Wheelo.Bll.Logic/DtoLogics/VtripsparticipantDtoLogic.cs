usignsad

asdasdasd

public class VtripsparticipantDtoLogic : DtoLogicBase<VtripsparticipantModelDto, Vtripsparticipant, IVtripsparticipantLogic, VtripsparticipantDto, List<Vtripsparticipant>, List<VtripsparticipantModelDto>>
{
    public VtripsparticipantDtoLogic(IVtripsparticipantLogic vtripsparticipantlogic) 
        : base(vtripsparticipantlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Vtripsparticipant = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vtripsparticipant,VtripsparticipantDto> GetDtoModelField(VtripsparticipantDto dto)
    {
       return dto.Vtripsparticipant;
    }

    protected override VtripsparticipantDto FillEntity(VtripsparticipantDto dto, DtoBase<Vtripsparticipant> field)
    {
        dto.Vtripsparticipant = (VtripsparticipantModelDto)field;

        return dto;
    }
}
