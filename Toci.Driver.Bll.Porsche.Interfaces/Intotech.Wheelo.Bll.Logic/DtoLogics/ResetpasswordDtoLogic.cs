using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic;

public class ResetpasswordDtoLogic : DtoLogicBase<ResetpasswordModelDto, Resetpassword, IResetpasswordLogic, ResetpasswordDto, List<Resetpassword>, List<ResetpasswordModelDto>>
{
    public ResetpasswordDtoLogic(IResetpasswordLogic resetpasswordlogic) 
        : base(resetpasswordlogic, 
            (aDto, aModelDto) => { 
                aDto.Resetpassword = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Resetpassword,ResetpasswordModelDto> GetDtoModelField(ResetpasswordDto dto)
    {
       return dto.Resetpassword;
    }

    protected override ResetpasswordDto FillEntity(ResetpasswordDto dto, ResetpasswordModelDto  field)
    {
        dto.Resetpassword = field;

        return dto;
    }    protected override ResetpasswordDto FillEntity(ResetpasswordDto dto, List<ResetpasswordModelDto> field)
    {
        throw new NotImplementedException();
    }
}
