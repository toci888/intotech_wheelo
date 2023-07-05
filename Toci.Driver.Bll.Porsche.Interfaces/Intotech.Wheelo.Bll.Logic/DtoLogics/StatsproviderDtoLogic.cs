using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic;

public class StatsproviderDtoLogic : DtoLogicBase<StatsproviderModelDto, Statsprovider, IStatsproviderLogic, StatsproviderDto, List<Statsprovider>, List<StatsproviderModelDto>>
{
    public StatsproviderDtoLogic(IStatsproviderLogic statsproviderlogic) 
        : base(statsproviderlogic, 
            (aDto, aModelDto) => { 
                aDto.Statsprovider = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Statsprovider,StatsproviderModelDto> GetDtoModelField(StatsproviderDto dto)
    {
       return dto.Statsprovider;
    }

    protected override StatsproviderDto FillEntity(StatsproviderDto dto, StatsproviderModelDto  field)
    {
        dto.Statsprovider = field;

        return dto;
    }    protected override StatsproviderDto FillEntity(StatsproviderDto dto, List<StatsproviderModelDto> field)
    {
        throw new NotImplementedException();
    }
}
