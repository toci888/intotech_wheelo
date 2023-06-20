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
    public AccountmetadatumDtoLogic(int accountId)
        : base(new AccountMetadataLogic(), m => m.Idaccount == accountId,
            (aDto, aMmDto) =>
            {
                aDto.Accountmetadatum = aMmDto;

                return aDto;
            })
    {

    }

    protected override DtoBase<Accountmetadatum> GetDtoModelField(AccountDto dto)
    {
       return dto.Accountmetadatum;
    }

    protected override AccountDto FillEntity(AccountDto dto, DtoBase<Accountmetadatum> field)
    {
        dto.Accountmetadatum = (AccountmetadatumModelDto)field;

        return dto;
    }
}
