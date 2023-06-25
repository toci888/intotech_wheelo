using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class CarDtoLogic : DtoLogicBase< CarModelDto , Car , CarLogic , CarDto >
{
    public CarDtoLogic(int id) 
        : base(new CarLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Car = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Car> GetDtoModelField(CarDto dto)
    {
       return dto.Car;
    }

    protected override CarDto FillEntity(CarDto dto, DtoBase<Car> field)
    {
        dto.Car = (CarModelDto)field;

        return dto;
    }
}
