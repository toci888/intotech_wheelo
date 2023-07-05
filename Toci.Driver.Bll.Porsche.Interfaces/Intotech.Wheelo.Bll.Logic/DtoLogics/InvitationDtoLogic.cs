using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic;

public class InvitationDtoLogic : DtoLogicBase<InvitationModelDto, Invitation, IInvitationLogic, InvitationDto, List<Invitation>, List<InvitationModelDto>>
{
    public InvitationDtoLogic(IInvitationLogic invitationlogic) 
        : base(invitationlogic, 
            (aDto, aModelDto) => { 
                aDto.Invitation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Invitation,InvitationModelDto> GetDtoModelField(InvitationDto dto)
    {
       return dto.Invitation;
    }

    protected override InvitationDto FillEntity(InvitationDto dto, InvitationModelDto  field)
    {
        dto.Invitation = field;

        return dto;
    }    protected override InvitationDto FillEntity(InvitationDto dto, List<InvitationModelDto> field)
    {
        throw new NotImplementedException();
    }
}
