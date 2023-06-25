using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class VaccountscollocationsworktripDtoLogic : DtoLogicBase< VaccountscollocationsworktripModelDto , Vaccountscollocationsworktrip , VaccountscollocationsworktripLogic , VaccountscollocationsworktripDto >
{
    public VaccountscollocationsworktripDtoLogic(int id) 
        : base(new VaccountscollocationsworktripLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Vaccountscollocationsworktrip = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vaccountscollocationsworktrip> GetDtoModelField(VaccountscollocationsworktripDto dto)
    {
       return dto.Vaccountscollocationsworktrip;
    }

    protected override VaccountscollocationsworktripDto FillEntity(VaccountscollocationsworktripDto dto, DtoBase<Vaccountscollocationsworktrip> field)
    {
        dto.Vaccountscollocationsworktrip = (VaccountscollocationsworktripModelDto)field;

        return dto;
    }
}
