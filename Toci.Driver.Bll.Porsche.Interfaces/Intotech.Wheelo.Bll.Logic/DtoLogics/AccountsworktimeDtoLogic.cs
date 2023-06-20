using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class AccountsworktimeDtoLogic : DtoLogicBase< AccountsworktimeModelDto , Accountsworktime , AccountsworktimeLogic , AccountsworktimeDto >
{
    public AccountsworktimeDtoLogic(int id) 
        : base(new AccountsworktimeLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Accountsworktime = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Accountsworktime> GetDtoModelField(AccountsworktimeDto dto)
    {
       return dto.Accountsworktime;
    }

    protected override AccountsworktimeDto FillEntity(AccountsworktimeDto dto, DtoBase<Accountsworktime> field)
    {
        dto.Accountsworktime = (AccountsworktimeModelDto)field;

        return dto;
    }
}
