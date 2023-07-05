usignsad

asdasdasd

public class CarsmodelDtoLogic : DtoLogicBase<CarsmodelModelDto, Carsmodel, ICarsmodelLogic, CarsmodelDto, List<Carsmodel>, List<CarsmodelModelDto>>
{
    public CarsmodelDtoLogic(ICarsmodelLogic carsmodellogic) 
        : base(carsmodellogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Carsmodel = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Carsmodel,CarsmodelDto> GetDtoModelField(CarsmodelDto dto)
    {
       return dto.Carsmodel;
    }

    protected override CarsmodelDto FillEntity(CarsmodelDto dto, DtoBase<Carsmodel> field)
    {
        dto.Carsmodel = (CarsmodelModelDto)field;

        return dto;
    }
}
