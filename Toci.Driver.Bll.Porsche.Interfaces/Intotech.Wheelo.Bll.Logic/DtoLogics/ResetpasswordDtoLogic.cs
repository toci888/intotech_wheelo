using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class ResetpasswordDtoLogic : DtoLogicBase< ResetpasswordModelDto , Resetpassword , ResetpasswordLogic , ResetpasswordDto >
{
    public ResetpasswordDtoLogic(int id) 
        : base(new ResetpasswordLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Resetpassword = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Resetpassword> GetDtoModelField(ResetpasswordDto dto)
    {
       return dto.Resetpassword;
    }

    protected override ResetpasswordDto FillEntity(ResetpasswordDto dto, DtoBase<Resetpassword> field)
    {
        dto.Resetpassword = (ResetpasswordModelDto)field;

        return dto;
    }
}
