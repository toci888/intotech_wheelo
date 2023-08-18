using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Wheelo.Bll.Models.DictionariesModelDto;
using Intotech.Wheelo.Bll.Models.DictionariesDto;
using Intotech.Wheelo.Dictionaries.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Dictionaries.Database.Persistence.Models;
using Intotech.Wheelo.Dictionaries.Bll.Logic.Interfaces.IDtoLogic;
using Intotech.Common.Bll.ChorDtoBll.Dto;

namespace Intotech.Wheelo.Dictionaries.Bll.Logic.DtoLogic;

public class CarsmodelDtoLogic : DtoLogicBase<CarsmodelModelDto, Carsmodel, ICarsmodelLogic, CarsmodelDto, List<Carsmodel>, List<CarsmodelModelDto>>, ICarsmodelDtoLogic
{
    public CarsmodelDtoLogic(ICarsmodelLogic carsmodellogic) 
        : base(carsmodellogic, 
            (aDto, aModelDto) => { 
                aDto.Carsmodel = aModelDto;
                return aDto;
            })
    {
    }

    protected override CarsmodelModelDto GetDtoModelField(CarsmodelDto dto)
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
