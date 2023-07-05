usignsad

asdasdasd

public class CarDtoLogic : DtoLogicBase<CarModelDto, Car, ICarLogic, CarDto, List<Car>, List<CarModelDto>>
{
    public CarDtoLogic(ICarLogic carlogic) 
        : base(carlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Car = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Car,CarDto> GetDtoModelField(CarDto dto)
    {
       return dto.Car;
    }

    protected override CarDto FillEntity(CarDto dto, DtoBase<Car> field)
    {
        dto.Car = (CarModelDto)field;

        return dto;
    }
}
