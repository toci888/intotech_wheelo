using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic;

public class VtripsparticipantDtoLogic : DtoLogicBase<VtripsparticipantModelDto, Vtripsparticipant, IVtripsparticipantLogic, VtripsparticipantDto, List<Vtripsparticipant>, List<VtripsparticipantModelDto>>
{
    public VtripsparticipantDtoLogic(IVtripsparticipantLogic vtripsparticipantlogic) 
        : base(vtripsparticipantlogic, 
            (aDto, aModelDto) => { 
                aDto.Vtripsparticipant = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vtripsparticipant,VtripsparticipantModelDto> GetDtoModelField(VtripsparticipantDto dto)
    {
       return dto.Vtripsparticipant;
    }

    protected override VtripsparticipantDto FillEntity(VtripsparticipantDto dto, VtripsparticipantModelDto  field)
    {
        dto.Vtripsparticipant = field;

        return dto;
    }    protected override VtripsparticipantDto FillEntity(VtripsparticipantDto dto, List<VtripsparticipantModelDto> field)
    {
        throw new NotImplementedException();
    }
}
