using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic;

public class VfriendsuggestionDtoLogic : DtoLogicBase<VfriendsuggestionModelDto, Vfriendsuggestion, IVfriendsuggestionLogic, VfriendsuggestionDto, List<Vfriendsuggestion>, List<VfriendsuggestionModelDto>>
{
    public VfriendsuggestionDtoLogic(IVfriendsuggestionLogic vfriendsuggestionlogic) 
        : base(vfriendsuggestionlogic, 
            (aDto, aModelDto) => { 
                aDto.Vfriendsuggestion = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vfriendsuggestion,VfriendsuggestionModelDto> GetDtoModelField(VfriendsuggestionDto dto)
    {
       return dto.Vfriendsuggestion;
    }

    protected override VfriendsuggestionDto FillEntity(VfriendsuggestionDto dto, VfriendsuggestionModelDto  field)
    {
        dto.Vfriendsuggestion = field;

        return dto;
    }    protected override VfriendsuggestionDto FillEntity(VfriendsuggestionDto dto, List<VfriendsuggestionModelDto> field)
    {
        throw new NotImplementedException();
    }
}
