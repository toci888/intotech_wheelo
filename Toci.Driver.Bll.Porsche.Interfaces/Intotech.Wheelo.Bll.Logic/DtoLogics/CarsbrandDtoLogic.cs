usignsad

asdasdasd

public class CarsbrandDtoLogic : DtoLogicBase<CarsbrandModelDto, Carsbrand, ICarsbrandLogic, CarsbrandDto, List<Carsbrand>, List<CarsbrandModelDto>>
{
    public CarsbrandDtoLogic(ICarsbrandLogic carsbrandlogic) 
        : base(carsbrandlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Carsbrand = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Carsbrand,CarsbrandDto> GetDtoModelField(CarsbrandDto dto)
    {
       return dto.Carsbrand;
    }

    protected override CarsbrandDto FillEntity(CarsbrandDto dto, DtoBase<Carsbrand> field)
    {
        dto.Carsbrand = (CarsbrandModelDto)field;

        return dto;
    }
}
