using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class AccountmetadatumDtoLogic : DtoLogicBase<AccountmetadatumModelDto, Accountmetadatum, AccountMetadataLogic, AccountDto> 
{
    public AccountmetadatumDtoLogic()
        : base(new AccountMetadataLogic(),
            (aDto, aMmDto) =>
            {
                aDto.Accountmetadatum = aMmDto;

                return aDto;
            })
    {

    }

    protected override DtoBase<Accountmetadatum, AccountmetadatumModelDto> GetDtoModelField(AccountDto dto)
    {
        return dto.Accountmetadatum;
    }

    protected override AccountDto FillEntity(AccountDto dto, AccountmetadatumModelDto field)
    {
        dto.Accountmetadatum = (AccountmetadatumModelDto)field;

        return dto;
    }
}