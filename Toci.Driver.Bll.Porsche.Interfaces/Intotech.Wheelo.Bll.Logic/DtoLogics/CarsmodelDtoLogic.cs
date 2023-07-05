using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic;

public class CarsmodelDtoLogic : DtoLogicBase<CarsmodelModelDto, Carsmodel, ICarsmodelLogic, CarsmodelDto, List<Carsmodel>, List<CarsmodelModelDto>>
{
    public CarsmodelDtoLogic(ICarsmodelLogic carsmodellogic) 
        : base(carsmodellogic, 
            (aDto, aModelDto) => { 
                aDto.Carsmodel = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Carsmodel,CarsmodelModelDto> GetDtoModelField(CarsmodelDto dto)
    {
       return dto.Carsmodel;
    }

    protected override CarsmodelDto FillEntity(CarsmodelDto dto, CarsmodelModelDto  field)
    {
        dto.Carsmodel = field;

        return dto;
    }    protected override CarsmodelDto FillEntity(CarsmodelDto dto, List<CarsmodelModelDto> field)
    {
        throw new NotImplementedException();
    }
}
