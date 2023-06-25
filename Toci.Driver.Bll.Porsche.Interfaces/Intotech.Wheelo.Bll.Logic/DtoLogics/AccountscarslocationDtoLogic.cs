using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class AccountscarslocationDtoLogic : DtoLogicBase< AccountscarslocationModelDto , Accountscarslocation , AccountscarslocationLogic , AccountscarslocationDto >
{
    public AccountscarslocationDtoLogic(int id) 
        : base(new AccountscarslocationLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Accountscarslocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Accountscarslocation> GetDtoModelField(AccountscarslocationDto dto)
    {
       return dto.Accountscarslocation;
    }

    protected override AccountscarslocationDto FillEntity(AccountscarslocationDto dto, DtoBase<Accountscarslocation> field)
    {
        dto.Accountscarslocation = (AccountscarslocationModelDto)field;

        return dto;
    }
}
