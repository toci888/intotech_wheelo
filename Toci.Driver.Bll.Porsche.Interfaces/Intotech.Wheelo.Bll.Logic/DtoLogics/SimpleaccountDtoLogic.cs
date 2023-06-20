using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class SimpleaccountDtoLogic : DtoLogicBase< SimpleaccountModelDto , Simpleaccount , SimpleaccountLogic , SimpleaccountDto >
{
    public SimpleaccountDtoLogic(int id) 
        : base(new SimpleaccountLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Simpleaccount = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Simpleaccount> GetDtoModelField(SimpleaccountDto dto)
    {
       return dto.Simpleaccount;
    }

    protected override SimpleaccountDto FillEntity(SimpleaccountDto dto, DtoBase<Simpleaccount> field)
    {
        dto.Simpleaccount = (SimpleaccountModelDto)field;

        return dto;
    }
}
