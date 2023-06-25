using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class VacollocationsgeolocationDtoLogic : DtoLogicBase< VacollocationsgeolocationModelDto , Vacollocationsgeolocation , VacollocationsgeolocationLogic , VacollocationsgeolocationDto >
{
    public VacollocationsgeolocationDtoLogic(int id) 
        : base(new VacollocationsgeolocationLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Vacollocationsgeolocation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vacollocationsgeolocation> GetDtoModelField(VacollocationsgeolocationDto dto)
    {
       return dto.Vacollocationsgeolocation;
    }

    protected override VacollocationsgeolocationDto FillEntity(VacollocationsgeolocationDto dto, DtoBase<Vacollocationsgeolocation> field)
    {
        dto.Vacollocationsgeolocation = (VacollocationsgeolocationModelDto)field;

        return dto;
    }
}
