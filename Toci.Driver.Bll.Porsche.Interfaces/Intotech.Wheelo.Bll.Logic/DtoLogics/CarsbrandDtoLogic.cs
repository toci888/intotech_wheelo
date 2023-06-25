using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class CarsbrandDtoLogic : DtoLogicBase< CarsbrandModelDto , Carsbrand , CarsbrandLogic , CarsbrandDto >
{
    public CarsbrandDtoLogic(int id) 
        : base(new CarsbrandLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Carsbrand = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Carsbrand> GetDtoModelField(CarsbrandDto dto)
    {
       return dto.Carsbrand;
    }

    protected override CarsbrandDto FillEntity(CarsbrandDto dto, DtoBase<Carsbrand> field)
    {
        dto.Carsbrand = (CarsbrandModelDto)field;

        return dto;
    }
}
