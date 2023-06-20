using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class TripDtoLogic : DtoLogicBase< TripModelDto , Trip , TripLogic , TripDto >
{
    public TripDtoLogic(int id) 
        : base(new TripLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Trip = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Trip> GetDtoModelField(TripDto dto)
    {
       return dto.Trip;
    }

    protected override TripDto FillEntity(TripDto dto, DtoBase<Trip> field)
    {
        dto.Trip = (TripModelDto)field;

        return dto;
    }
}
