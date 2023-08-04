using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;


namespace Intotech.Wheelo.Bll.Logic;


public class TripDtoLogic : DtoLogicBase<TripModelDto, Trip, ITripLogic, TripDto, List<Trip>, List<TripModelDto>>, ITripDtoLogic
{
    public TripDtoLogic(ITripLogic triplogic) 
        : base(triplogic, 
            (aDto, aModelDto) => { 
                aDto.Trip = aModelDto;
                return aDto;
            })
    {
    }

    protected override TripModelDto GetDtoModelField(TripDto dto)
    {
       return dto.Trip;
    }

    protected override TripDto FillEntity(TripDto dto, TripModelDto  field)
    {
        dto.Trip = field;

        return dto;
    }    protected override TripDto FillEntity(TripDto dto, List<TripModelDto> field)
    {
        throw new NotImplementedException();
    }
}
