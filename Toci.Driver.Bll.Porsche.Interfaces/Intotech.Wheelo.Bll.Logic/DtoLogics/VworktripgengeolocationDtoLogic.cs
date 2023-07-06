using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic;

public class VworktripgengeolocationDtoLogic : DtoLogicBase<VworktripgengeolocationModelDto, Vworktripgengeolocation, IVworktripgengeolocationLogic, VworktripgengeolocationDto, List<Vworktripgengeolocation>, List<VworktripgengeolocationModelDto>>
{
    public VworktripgengeolocationDtoLogic(IVworktripgengeolocationLogic vworktripgengeolocationlogic) 
        : base(vworktripgengeolocationlogic, 
            (aDto, aModelDto) => { 
                aDto.Vworktripgengeolocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vworktripgengeolocation,VworktripgengeolocationModelDto> GetDtoModelField(VworktripgengeolocationDto dto)
    {
       return dto.Vworktripgengeolocation;
    }

    protected override VworktripgengeolocationDto FillEntity(VworktripgengeolocationDto dto, VworktripgengeolocationModelDto  field)
    {
        dto.Vworktripgengeolocation = field;

        return dto;
    }    protected override VworktripgengeolocationDto FillEntity(VworktripgengeolocationDto dto, List<VworktripgengeolocationModelDto> field)
    {
        throw new NotImplementedException();
    }
}
