using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class NotuserDtoLogic : DtoLogicBase< NotuserModelDto , Notuser , NotuserLogic , NotuserDto >
{
    public NotuserDtoLogic(int id) 
        : base(new NotuserLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Notuser = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Notuser> GetDtoModelField(NotuserDto dto)
    {
       return dto.Notuser;
    }

    protected override NotuserDto FillEntity(NotuserDto dto, DtoBase<Notuser> field)
    {
        dto.Notuser = (NotuserModelDto)field;

        return dto;
    }
}
