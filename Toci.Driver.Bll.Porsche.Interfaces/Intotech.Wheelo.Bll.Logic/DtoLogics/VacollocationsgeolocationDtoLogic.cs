using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;

namespace Intotech.Wheelo.Bll.Logic;

public class VacollocationsgeolocationDtoLogic : DtoLogicBase<VacollocationsgeolocationModelDto, Vacollocationsgeolocation, IVacollocationsgeolocationLogic, VacollocationsgeolocationDto, List<Vacollocationsgeolocation>, List<VacollocationsgeolocationModelDto>>, IVacollocationsgeolocationDtoLogic
{
    public VacollocationsgeolocationDtoLogic(IVacollocationsgeolocationLogic vacollocationsgeolocationlogic) 
        : base(vacollocationsgeolocationlogic, 
            (aDto, aModelDto) => { 
                aDto.Vacollocationsgeolocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vacollocationsgeolocation,VacollocationsgeolocationModelDto> GetDtoModelField(VacollocationsgeolocationDto dto)
    {
       return dto.Vacollocationsgeolocation;
    }

    protected override VacollocationsgeolocationDto FillEntity(VacollocationsgeolocationDto dto, VacollocationsgeolocationModelDto  field)
    {
        dto.Vacollocationsgeolocation = field;

        return dto;
    }    protected override VacollocationsgeolocationDto FillEntity(VacollocationsgeolocationDto dto, List<VacollocationsgeolocationModelDto> field)
    {
        throw new NotImplementedException();
    }
}
