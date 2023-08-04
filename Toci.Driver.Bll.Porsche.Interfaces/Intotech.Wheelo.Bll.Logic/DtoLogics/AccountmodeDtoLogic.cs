using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;


namespace Intotech.Wheelo.Bll.Logic;


public class AccountmodeDtoLogic : DtoLogicBase<AccountmodeModelDto, Accountmode, IAccountmodeLogic, AccountmodeDto, List<Accountmode>, List<AccountmodeModelDto>>, IAccountmodeDtoLogic
{
    public AccountmodeDtoLogic(IAccountmodeLogic accountmodelogic) 
        : base(accountmodelogic, 
            (aDto, aModelDto) => { 
                aDto.Accountmode = aModelDto;
                return aDto;
            })
    {
    }

    protected override AccountmodeModelDto GetDtoModelField(AccountmodeDto dto)
    {
       return dto.Accountmode;
    }

    protected override AccountmodeDto FillEntity(AccountmodeDto dto, AccountmodeModelDto  field)
    {
        dto.Accountmode = field;

        return dto;
    }    protected override AccountmodeDto FillEntity(AccountmodeDto dto, List<AccountmodeModelDto> field)
    {
        throw new NotImplementedException();
    }
}
