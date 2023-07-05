using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic;

public class CarsbrandDtoLogic : DtoLogicBase<CarsbrandModelDto, Carsbrand, ICarsbrandLogic, CarsbrandDto, List<Carsbrand>, List<CarsbrandModelDto>>
{
    public CarsbrandDtoLogic(ICarsbrandLogic carsbrandlogic) 
        : base(carsbrandlogic, 
            (aDto, aModelDto) => { 
                aDto.Carsbrand = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Carsbrand,CarsbrandModelDto> GetDtoModelField(CarsbrandDto dto)
    {
       return dto.Carsbrand;
    }

    protected override CarsbrandDto FillEntity(CarsbrandDto dto, CarsbrandModelDto  field)
    {
        dto.Carsbrand = field;

        return dto;
    }    protected override CarsbrandDto FillEntity(CarsbrandDto dto, List<CarsbrandModelDto> field)
    {
        throw new NotImplementedException();
    }
}
