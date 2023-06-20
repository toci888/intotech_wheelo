using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class VworktripgengeolocationDtoLogic : DtoLogicBase< VworktripgengeolocationModelDto , Vworktripgengeolocation , VworktripgengeolocationLogic , VworktripgengeolocationDto >
{
    public VworktripgengeolocationDtoLogic(int id) 
        : base(new VworktripgengeolocationLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Vworktripgengeolocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vworktripgengeolocation> GetDtoModelField(VworktripgengeolocationDto dto)
    {
       return dto.Vworktripgengeolocation;
    }

    protected override VworktripgengeolocationDto FillEntity(VworktripgengeolocationDto dto, DtoBase<Vworktripgengeolocation> field)
    {
        dto.Vworktripgengeolocation = (VworktripgengeolocationModelDto)field;

        return dto;
    }
}
