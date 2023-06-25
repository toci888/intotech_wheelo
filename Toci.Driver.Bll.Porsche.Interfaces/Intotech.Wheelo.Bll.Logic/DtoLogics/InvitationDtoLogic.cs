using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class InvitationDtoLogic : DtoLogicBase< InvitationModelDto , Invitation , InvitationLogic , VInvitationDto >
{
    public InvitationDtoLogic(int id) 
        : base(new InvitationLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Invitation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Invitation> GetDtoModelField(InvitationDto dto)
    {
       return dto.Invitation;
    }

    protected override InvitationDto FillEntity(InvitationDto dto, DtoBase<Invitation> field)
    {
        dto.Invitation = (InvitationModelDto)field;

        return dto;
    }
}
