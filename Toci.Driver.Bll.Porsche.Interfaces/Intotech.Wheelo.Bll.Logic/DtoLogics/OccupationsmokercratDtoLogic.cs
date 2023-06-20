using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class OccupationsmokercratDtoLogic : DtoLogicBase< OccupationsmokercratModelDto , Occupationsmokercrat , OccupationsmokercratLogic , OccupationsmokercratDto >
{
    public OccupationsmokercratDtoLogic(int id) 
        : base(new OccupationsmokercratLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Occupationsmokercrat = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Occupationsmokercrat> GetDtoModelField(OccupationsmokercratDto dto)
    {
       return dto.Occupationsmokercrat;
    }

    protected override OccupationsmokercratDto FillEntity(OccupationsmokercratDto dto, DtoBase<Occupationsmokercrat> field)
    {
        dto.Occupationsmokercrat = (OccupationsmokercratModelDto)field;

        return dto;
    }
}
