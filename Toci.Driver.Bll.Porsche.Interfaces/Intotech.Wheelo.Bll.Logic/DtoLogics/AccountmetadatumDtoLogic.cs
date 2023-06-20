using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class AccountmetadatumDtoLogic : DtoLogicBase< AccountmetadatumModelDto , Accountmetadatum , AccountmetadatumLogic , AccountmetadatumDto >
{
    public AccountmetadatumDtoLogic(int id) 
        : base(new AccountmetadatumLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Accountmetadatum = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Accountmetadatum> GetDtoModelField(AccountmetadatumDto dto)
    {
       return dto.Accountmetadatum;
    }

    protected override AccountmetadatumDto FillEntity(AccountmetadatumDto dto, DtoBase<Accountmetadatum> field)
    {
        dto.Accountmetadatum = (AccountmetadatumModelDto)field;

        return dto;
    }
}
