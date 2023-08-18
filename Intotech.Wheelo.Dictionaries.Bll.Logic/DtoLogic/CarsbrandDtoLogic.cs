using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Wheelo.Bll.Models.DictionariesModelDto;
using Intotech.Wheelo.Bll.Models.DictionariesDto;
using Intotech.Wheelo.Dictionaries.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Dictionaries.Database.Persistence.Models;
using Intotech.Wheelo.Dictionaries.Bll.Logic.Interfaces.IDtoLogic;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Common.Bll.Interfaces;

namespace Intotech.Wheelo.Dictionaries.Bll.Logic.DtoLogic;

public class CarsbrandDtoLogic : DtoLogicBase<CarsbrandModelDto, Carsbrand, ICarsbrandLogic, CarsbrandDto, List<Carsbrand>, List<CarsbrandModelDto>>, ICarsbrandDtoLogic
{
    public CarsbrandDtoLogic(ICarsbrandLogic carsbrandlogic) 
        : base(carsbrandlogic, 
            (aDto, aModelDto) => { 
                aDto.Carsbrand = aModelDto;
                return aDto;
            })
    {
    }

    protected override CarsbrandModelDto GetDtoModelField(CarsbrandDto dto)
    {
       return dto.Carsbrand;
    }

    protected override CarsbrandDto FillEntity(CarsbrandDto dto, CarsbrandModelDto  field)
    {
        dto.Carsbrand = field;

        return dto;
    }    
    
    protected override CarsbrandDto FillEntity(CarsbrandDto dto, List<CarsbrandModelDto> field)
    {
        throw new NotImplementedException();
    }
}
