using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class StatsproviderDtoLogic : DtoLogicBase< StatsproviderModelDto , Statsprovider , StatsproviderLogic , StatsproviderDto >
{
    public StatsproviderDtoLogic(int id) 
        : base(new StatsproviderLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Statsprovider = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Statsprovider> GetDtoModelField(StatsproviderDto dto)
    {
       return dto.Statsprovider;
    }

    protected override StatsproviderDto FillEntity(StatsproviderDto dto, DtoBase<Statsprovider> field)
    {
        dto.Statsprovider = (StatsproviderModelDto)field;

        return dto;
    }
}
