using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class VinvitationDtoLogic : DtoLogicBase< VinvitationModelDto , Vinvitation , VinvitationLogic , VinvitationDto >
{
    public VinvitationDtoLogic(int id) 
        : base(new VinvitationLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Vinvitation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vinvitation> GetDtoModelField(VinvitationDto dto)
    {
       return dto.Vinvitation;
    }

    protected override VinvitationDto FillEntity(VinvitationDto dto, DtoBase<Vinvitation> field)
    {
        dto.Vinvitation = (VinvitationModelDto)field;

        return dto;
    }
}
