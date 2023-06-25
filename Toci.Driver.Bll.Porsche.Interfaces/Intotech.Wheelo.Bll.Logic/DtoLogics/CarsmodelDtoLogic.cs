using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class CarsmodelDtoLogic : DtoLogicBase< CarsmodelModelDto , Carsmodel , CarsmodelLogic , CarsmodelDto >
{
    public CarsmodelDtoLogic(int id) 
        : base(new CarsmodelLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Carsmodel = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Carsmodel> GetDtoModelField(CarsmodelDto dto)
    {
       return dto.Carsmodel;
    }

    protected override CarsmodelDto FillEntity(CarsmodelDto dto, DtoBase<Carsmodel> field)
    {
        dto.Carsmodel = (CarsmodelModelDto)field;

        return dto;
    }
}
