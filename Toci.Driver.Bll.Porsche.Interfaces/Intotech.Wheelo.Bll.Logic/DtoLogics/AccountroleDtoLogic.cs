using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;


namespace Intotech.Wheelo.Bll.Logic;


public class AccountroleDtoLogic : DtoLogicBase<AccountroleModelDto, Accountrole, IAccountroleLogic, AccountroleDto, List<Accountrole>, List<AccountroleModelDto>>, IAccountroleDtoLogic
{
    public AccountroleDtoLogic(IAccountroleLogic accountrolelogic) 
        : base(accountrolelogic, 
            (aDto, aModelDto) => { 
                aDto.Accountrole = aModelDto;
                return aDto;
            })
    {
    }

    protected override AccountroleModelDto GetDtoModelField(AccountroleDto dto)
    {
       return dto.Accountrole;
    }

    protected override AccountroleDto FillEntity(AccountroleDto dto, AccountroleModelDto  field)
    {
        dto.Accountrole = field;

        return dto;
    }    protected override AccountroleDto FillEntity(AccountroleDto dto, List<AccountroleModelDto> field)
    {
        throw new NotImplementedException();
    }
}
