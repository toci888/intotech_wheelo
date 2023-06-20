using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class VcollocationsgeolocationDtoLogic : DtoLogicBase< VcollocationsgeolocationModelDto , Vcollocationsgeolocation , VcollocationsgeolocationLogic , VcollocationsgeolocationDto >
{
    public VcollocationsgeolocationDtoLogic(int id) 
        : base(new VcollocationsgeolocationLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Vcollocationsgeolocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vcollocationsgeolocation> GetDtoModelField(VcollocationsgeolocationDto dto)
    {
       return dto.Vcollocationsgeolocation;
    }

    protected override VcollocationsgeolocationDto FillEntity(VcollocationsgeolocationDto dto, DtoBase<Vcollocationsgeolocation> field)
    {
        dto.Vcollocationsgeolocation = (VcollocationsgeolocationModelDto)field;

        return dto;
    }
}
