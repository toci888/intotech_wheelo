using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic;

public class VaworktripgengeolocationDtoLogic : DtoLogicBase<VaworktripgengeolocationModelDto, Vaworktripgengeolocation, IVaworktripgengeolocationLogic, VaworktripgengeolocationDto, List<Vaworktripgengeolocation>, List<VaworktripgengeolocationModelDto>>
{
    public VaworktripgengeolocationDtoLogic(IVaworktripgengeolocationLogic vaworktripgengeolocationlogic) 
        : base(vaworktripgengeolocationlogic, 
            (aDto, aModelDto) => { 
                aDto.Vaworktripgengeolocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vaworktripgengeolocation,VaworktripgengeolocationModelDto> GetDtoModelField(VaworktripgengeolocationDto dto)
    {
       return dto.Vaworktripgengeolocation;
    }

    protected override VaworktripgengeolocationDto FillEntity(VaworktripgengeolocationDto dto, VaworktripgengeolocationModelDto  field)
    {
        dto.Vaworktripgengeolocation = field;

        return dto;
    }    protected override VaworktripgengeolocationDto FillEntity(VaworktripgengeolocationDto dto, List<VaworktripgengeolocationModelDto> field)
    {
        throw new NotImplementedException();
    }
}
