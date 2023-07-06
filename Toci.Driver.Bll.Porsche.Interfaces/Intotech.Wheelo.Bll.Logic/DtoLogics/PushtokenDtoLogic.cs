using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;

namespace Intotech.Wheelo.Bll.Logic;

public class PushtokenDtoLogic : DtoLogicBase<PushtokenModelDto, Pushtoken, IPushtokenLogic, PushtokenDto, List<Pushtoken>, List<PushtokenModelDto>>, IPushtokenDtoLogic
{
    public PushtokenDtoLogic(IPushtokenLogic pushtokenlogic) 
        : base(pushtokenlogic, 
            (aDto, aModelDto) => { 
                aDto.Pushtoken = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Pushtoken,PushtokenModelDto> GetDtoModelField(PushtokenDto dto)
    {
       return dto.Pushtoken;
    }

    protected override PushtokenDto FillEntity(PushtokenDto dto, PushtokenModelDto  field)
    {
        dto.Pushtoken = field;

        return dto;
    }    protected override PushtokenDto FillEntity(PushtokenDto dto, List<PushtokenModelDto> field)
    {
        throw new NotImplementedException();
    }
}
