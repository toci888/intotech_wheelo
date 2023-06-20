using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class VaworktripgengeolocationDtoLogic : DtoLogicBase< VaworktripgengeolocationModelDto , Vaworktripgengeolocation , VaworktripgengeolocationLogic , VaworktripgengeolocationDto >
{
    public VaworktripgengeolocationDtoLogic(int id) 
        : base(new VaworktripgengeolocationLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Vaworktripgengeolocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vaworktripgengeolocation> GetDtoModelField(VaworktripgengeolocationDto dto)
    {
       return dto.Vaworktripgengeolocation;
    }

    protected override VaworktripgengeolocationDto FillEntity(VaworktripgengeolocationDto dto, DtoBase<Vaworktripgengeolocation> field)
    {
        dto.Vaworktripgengeolocation = (VaworktripgengeolocationModelDto)field;

        return dto;
    }
}
