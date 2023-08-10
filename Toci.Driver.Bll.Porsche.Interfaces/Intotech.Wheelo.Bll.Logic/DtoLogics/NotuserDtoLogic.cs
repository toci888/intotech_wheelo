using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;

namespace Intotech.Wheelo.Bll.Logic;

public class NotuserDtoLogic : DtoLogicBase<NotuserModelDto, Notuser, INotuserLogic, NotuserDto, List<Notuser>, List<NotuserModelDto>>, INotuserDtoLogic
{
    public NotuserDtoLogic(INotuserLogic notuserlogic) 
        : base(notuserlogic, 
            (aDto, aModelDto) => { 
                aDto.Notuser = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Notuser,NotuserModelDto> GetDtoModelField(NotuserDto dto)
    {
       return dto.Notuser;
    }

    protected override NotuserDto FillEntity(NotuserDto dto, NotuserModelDto  field)
    {
        dto.Notuser = field;

        return dto;
    }    protected override NotuserDto FillEntity(NotuserDto dto, List<NotuserModelDto> field)
    {
        throw new NotImplementedException();
    }
}
