usignsad

asdasdasd

public class InvitationDtoLogic : DtoLogicBase<InvitationModelDto, Invitation, IInvitationLogic, InvitationDto, List<Invitation>, List<InvitationModelDto>>
{
    public InvitationDtoLogic(IInvitationLogic invitationlogic) 
        : base(invitationlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Invitation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Invitation,InvitationDto> GetDtoModelField(InvitationDto dto)
    {
       return dto.Invitation;
    }

    protected override InvitationDto FillEntity(InvitationDto dto, DtoBase<Invitation> field)
    {
        dto.Invitation = (InvitationModelDto)field;

        return dto;
    }
}
