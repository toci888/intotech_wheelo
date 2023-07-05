using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic;

public class VinvitationDtoLogic : DtoLogicBase<VinvitationModelDto, Vinvitation, IVinvitationLogic, VinvitationDto, List<Vinvitation>, List<VinvitationModelDto>>
{
    public VinvitationDtoLogic(IVinvitationLogic vinvitationlogic) 
        : base(vinvitationlogic, 
            (aDto, aModelDto) => { 
                aDto.Vinvitation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vinvitation,VinvitationModelDto> GetDtoModelField(VinvitationDto dto)
    {
       return dto.Vinvitation;
    }

    protected override VinvitationDto FillEntity(VinvitationDto dto, VinvitationModelDto  field)
    {
        dto.Vinvitation = field;

        return dto;
    }    protected override VinvitationDto FillEntity(VinvitationDto dto, List<VinvitationModelDto> field)
    {
        throw new NotImplementedException();
    }
}
