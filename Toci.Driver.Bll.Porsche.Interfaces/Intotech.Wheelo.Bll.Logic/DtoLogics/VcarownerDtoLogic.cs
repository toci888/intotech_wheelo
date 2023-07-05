usignsad

asdasdasd

public class VcarownerDtoLogic : DtoLogicBase<VcarownerModelDto, Vcarowner, IVcarownerLogic, VcarownerDto, List<Vcarowner>, List<VcarownerModelDto>>
{
    public VcarownerDtoLogic(IVcarownerLogic vcarownerlogic) 
        : base(vcarownerlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Vcarowner = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vcarowner,VcarownerDto> GetDtoModelField(VcarownerDto dto)
    {
       return dto.Vcarowner;
    }

    protected override VcarownerDto FillEntity(VcarownerDto dto, DtoBase<Vcarowner> field)
    {
        dto.Vcarowner = (VcarownerModelDto)field;

        return dto;
    }
}
