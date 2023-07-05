usignsad

asdasdasd

public class VinvitationDtoLogic : DtoLogicBase<VinvitationModelDto, Vinvitation, IVinvitationLogic, VinvitationDto, List<Vinvitation>, List<VinvitationModelDto>>
{
    public VinvitationDtoLogic(IVinvitationLogic vinvitationlogic) 
        : base(vinvitationlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Vinvitation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vinvitation,VinvitationDto> GetDtoModelField(VinvitationDto dto)
    {
       return dto.Vinvitation;
    }

    protected override VinvitationDto FillEntity(VinvitationDto dto, DtoBase<Vinvitation> field)
    {
        dto.Vinvitation = (VinvitationModelDto)field;

        return dto;
    }
}
