using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class WorktripDtoLogic : DtoLogicBase< WorktripModelDto , Worktrip , WorktripLogic , WorktripDto >
{
    public WorktripDtoLogic(int id) 
        : base(new WorktripLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Worktrip = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Worktrip> GetDtoModelField(WorktripDto dto)
    {
       return dto.Worktrip;
    }

    protected override WorktripDto FillEntity(WorktripDto dto, DtoBase<Worktrip> field)
    {
        dto.Worktrip = (WorktripModelDto)field;

        return dto;
    }
}
