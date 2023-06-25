using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class PushtokenDtoLogic : DtoLogicBase< PushtokenModelDto , Pushtoken , PushtokenLogic , PushtokenDto >
{
    public PushtokenDtoLogic(int id) 
        : base(new PushtokenLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Pushtoken = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Pushtoken> GetDtoModelField(PushtokenDto dto)
    {
       return dto.Pushtoken;
    }

    protected override PushtokenDto FillEntity(PushtokenDto dto, DtoBase<Pushtoken> field)
    {
        dto.Pushtoken = (PushtokenModelDto)field;

        return dto;
    }
}
