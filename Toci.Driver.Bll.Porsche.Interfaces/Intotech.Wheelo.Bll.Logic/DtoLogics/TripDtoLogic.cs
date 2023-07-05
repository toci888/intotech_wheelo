usignsad

asdasdasd

public class TripDtoLogic : DtoLogicBase<TripModelDto, Trip, ITripLogic, TripDto, List<Trip>, List<TripModelDto>>
{
    public TripDtoLogic(ITripLogic triplogic) 
        : base(triplogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Trip = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Trip,TripDto> GetDtoModelField(TripDto dto)
    {
       return dto.Trip;
    }

    protected override TripDto FillEntity(TripDto dto, DtoBase<Trip> field)
    {
        dto.Trip = (TripModelDto)field;

        return dto;
    }
}
