using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;

namespace Intotech.Wheelo.Bll.Logic;

public class VcarownerDtoLogic : DtoLogicBase<VcarownerModelDto, Vcarowner, IVcarownerLogic, VcarownerDto, List<Vcarowner>, List<VcarownerModelDto>>, IVcarownerDtoLogic
{
    public VcarownerDtoLogic(IVcarownerLogic vcarownerlogic) 
        : base(vcarownerlogic, 
            (aDto, aModelDto) => { 
                aDto.Vcarowner = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vcarowner,VcarownerModelDto> GetDtoModelField(VcarownerDto dto)
    {
       return dto.Vcarowner;
    }

    protected override VcarownerDto FillEntity(VcarownerDto dto, VcarownerModelDto  field)
    {
        dto.Vcarowner = field;

        return dto;
    }    protected override VcarownerDto FillEntity(VcarownerDto dto, List<VcarownerModelDto> field)
    {
        throw new NotImplementedException();
    }
}
