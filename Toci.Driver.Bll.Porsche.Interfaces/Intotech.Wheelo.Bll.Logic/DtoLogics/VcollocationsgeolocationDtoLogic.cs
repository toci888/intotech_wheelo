using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic;

public class VcollocationsgeolocationDtoLogic : DtoLogicBase<VcollocationsgeolocationModelDto, Vcollocationsgeolocation, IVcollocationsgeolocationLogic, VcollocationsgeolocationDto, List<Vcollocationsgeolocation>, List<VcollocationsgeolocationModelDto>>
{
    public VcollocationsgeolocationDtoLogic(IVcollocationsgeolocationLogic vcollocationsgeolocationlogic) 
        : base(vcollocationsgeolocationlogic, 
            (aDto, aModelDto) => { 
                aDto.Vcollocationsgeolocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vcollocationsgeolocation,VcollocationsgeolocationModelDto> GetDtoModelField(VcollocationsgeolocationDto dto)
    {
       return dto.Vcollocationsgeolocation;
    }

    protected override VcollocationsgeolocationDto FillEntity(VcollocationsgeolocationDto dto, VcollocationsgeolocationModelDto  field)
    {
        dto.Vcollocationsgeolocation = field;

        return dto;
    }    protected override VcollocationsgeolocationDto FillEntity(VcollocationsgeolocationDto dto, List<VcollocationsgeolocationModelDto> field)
    {
        throw new NotImplementedException();
    }
}
