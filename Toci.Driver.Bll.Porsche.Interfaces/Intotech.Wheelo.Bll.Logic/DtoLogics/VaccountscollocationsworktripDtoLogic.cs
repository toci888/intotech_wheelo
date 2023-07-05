usignsad

asdasdasd

public class VaccountscollocationsworktripDtoLogic : DtoLogicBase<VaccountscollocationsworktripModelDto, Vaccountscollocationsworktrip, IVaccountscollocationsworktripLogic, VaccountscollocationsworktripDto, List<Vaccountscollocationsworktrip>, List<VaccountscollocationsworktripModelDto>>
{
    public VaccountscollocationsworktripDtoLogic(IVaccountscollocationsworktripLogic vaccountscollocationsworktriplogic) 
        : base(vaccountscollocationsworktriplogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Vaccountscollocationsworktrip = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vaccountscollocationsworktrip,VaccountscollocationsworktripDto> GetDtoModelField(VaccountscollocationsworktripDto dto)
    {
       return dto.Vaccountscollocationsworktrip;
    }

    protected override VaccountscollocationsworktripDto FillEntity(VaccountscollocationsworktripDto dto, DtoBase<Vaccountscollocationsworktrip> field)
    {
        dto.Vaccountscollocationsworktrip = (VaccountscollocationsworktripModelDto)field;

        return dto;
    }
}
