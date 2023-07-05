using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic;

public class CarDtoLogic : DtoLogicBase<CarModelDto, Car, ICarLogic, CarDto, List<Car>, List<CarModelDto>>
{
    public CarDtoLogic(ICarLogic carlogic) 
        : base(carlogic, 
            (aDto, aModelDto) => { 
                aDto.Car = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Car,CarModelDto> GetDtoModelField(CarDto dto)
    {
       return dto.Car;
    }

    protected override CarDto FillEntity(CarDto dto, CarModelDto  field)
    {
        dto.Car = field;

        return dto;
    }    protected override CarDto FillEntity(CarDto dto, List<CarModelDto> field)
    {
        throw new NotImplementedException();
    }
}
