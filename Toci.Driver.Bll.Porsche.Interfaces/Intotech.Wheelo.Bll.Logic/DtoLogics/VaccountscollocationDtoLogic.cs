using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class VaccountscollocationDtoLogic : DtoLogicBase< VaccountscollocationModelDto , Vaccountscollocation , VaccountscollocationLogic , VaccountscollocationDto >
{
    public VaccountscollocationDtoLogic(int id) 
        : base(new VaccountscollocationLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Vaccountscollocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vaccountscollocation> GetDtoModelField(VaccountscollocationDto dto)
    {
       return dto.Vaccountscollocation;
    }

    protected override VaccountscollocationDto FillEntity(VaccountscollocationDto dto, DtoBase<Vaccountscollocation> field)
    {
        dto.Vaccountscollocation = (VaccountscollocationModelDto)field;

        return dto;
    }
}
