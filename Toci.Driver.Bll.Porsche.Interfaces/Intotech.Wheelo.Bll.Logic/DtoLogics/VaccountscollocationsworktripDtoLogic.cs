using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;

namespace Intotech.Wheelo.Bll.Logic;

public class VaccountscollocationsworktripDtoLogic : DtoLogicBase<VaccountscollocationsworktripModelDto, Vaccountscollocationsworktrip, IVaccountscollocationsworktripLogic, VaccountscollocationsworktripDto, List<Vaccountscollocationsworktrip>, List<VaccountscollocationsworktripModelDto>>, IVaccountscollocationsworktripDtoLogic
{
    public VaccountscollocationsworktripDtoLogic(IVaccountscollocationsworktripLogic vaccountscollocationsworktriplogic) 
        : base(vaccountscollocationsworktriplogic, 
            (aDto, aModelDto) => { 
                aDto.Vaccountscollocationsworktrip = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vaccountscollocationsworktrip,VaccountscollocationsworktripModelDto> GetDtoModelField(VaccountscollocationsworktripDto dto)
    {
       return dto.Vaccountscollocationsworktrip;
    }

    protected override VaccountscollocationsworktripDto FillEntity(VaccountscollocationsworktripDto dto, VaccountscollocationsworktripModelDto  field)
    {
        dto.Vaccountscollocationsworktrip = field;

        return dto;
    }    protected override VaccountscollocationsworktripDto FillEntity(VaccountscollocationsworktripDto dto, List<VaccountscollocationsworktripModelDto> field)
    {
        throw new NotImplementedException();
    }
}
