

namespace Intotech.Wheelo.Dictionaries.Bll.Logic;

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
