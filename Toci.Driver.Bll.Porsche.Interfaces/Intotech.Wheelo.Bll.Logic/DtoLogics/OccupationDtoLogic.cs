using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class OccupationDtoLogic : DtoLogicBase< OccupationModelDto , Occupation , OccupationLogic , OccupationDto >
{
    public OccupationDtoLogic(int id) 
        : base(new OccupationLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Occupation = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Occupation> GetDtoModelField(OccupationDto dto)
    {
       return dto.Occupation;
    }

    protected override OccupationDto FillEntity(OccupationDto dto, DtoBase<Occupation> field)
    {
        dto.Occupation = (OccupationModelDto)field;

        return dto;
    }
}
