using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class AccountmodeDtoLogic : DtoLogicBase< AccountmodeModelDto , Accountmode , AccountmodeLogic , AccountmodeDto >
{
    public AccountmodeDtoLogic(int id) 
        : base(new AccountmodeLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Accountmode = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Accountmode> GetDtoModelField(AccountmodeDto dto)
    {
       return dto.Accountmode;
    }

    protected override AccountmodeDto FillEntity(AccountmodeDto dto, DtoBase<Accountmode> field)
    {
        dto.Accountmode = (AccountmodeModelDto)field;

        return dto;
    }
}
