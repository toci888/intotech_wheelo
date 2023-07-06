using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic;

public class VcarownerDtoLogic : DtoLogicBase<VcarownerModelDto, Vcarowner, IVcarownerLogic, VcarownerDto, List<Vcarowner>, List<VcarownerModelDto>>
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
