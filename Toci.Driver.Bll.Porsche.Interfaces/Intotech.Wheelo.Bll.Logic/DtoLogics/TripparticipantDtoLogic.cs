using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;


namespace Intotech.Wheelo.Bll.Logic;


public class TripparticipantDtoLogic : DtoLogicBase<TripparticipantModelDto, Tripparticipant, ITripparticipantLogic, TripparticipantDto, List<Tripparticipant>, List<TripparticipantModelDto>>, ITripparticipantDtoLogic
{
    public TripparticipantDtoLogic(ITripparticipantLogic tripparticipantlogic) 
        : base(tripparticipantlogic, 
            (aDto, aModelDto) => { 
                aDto.Tripparticipant = aModelDto;
                return aDto;
            })
    {
    }

    protected override TripparticipantModelDto GetDtoModelField(TripparticipantDto dto)
    {
       return dto.Tripparticipant;
    }

    protected override TripparticipantDto FillEntity(TripparticipantDto dto, TripparticipantModelDto  field)
    {
        dto.Tripparticipant = field;

        return dto;
    }    protected override TripparticipantDto FillEntity(TripparticipantDto dto, List<TripparticipantModelDto> field)
    {
        throw new NotImplementedException();
    }
}
