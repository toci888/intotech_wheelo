using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;


namespace Intotech.Wheelo.Bll.Logic;


public class VaworktripgengeolocationDtoLogic : DtoLogicBase<VaworktripgengeolocationModelDto, Vaworktripgengeolocation, IVaworktripgengeolocationLogic, VaworktripgengeolocationDto, List<Vaworktripgengeolocation>, List<VaworktripgengeolocationModelDto>>, IVaworktripgengeolocationDtoLogic
{
    public VaworktripgengeolocationDtoLogic(IVaworktripgengeolocationLogic vaworktripgengeolocationlogic) 
        : base(vaworktripgengeolocationlogic, 
            (aDto, aModelDto) => { 
                aDto.Vaworktripgengeolocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override VaworktripgengeolocationModelDto GetDtoModelField(VaworktripgengeolocationDto dto)
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
