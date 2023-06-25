using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class WorktripgenDtoLogic : DtoLogicBase< WorktripgenModelDto , Worktripgen , WorktripgenLogic , WorktripgenDto >
{
    public WorktripgenDtoLogic(int id) 
        : base(new WorktripgenLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Worktripgen = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Worktripgen> GetDtoModelField(WorktripgenDto dto)
    {
       return dto.Worktripgen;
    }

    protected override WorktripgenDto FillEntity(WorktripgenDto dto, DtoBase<Worktripgen> field)
    {
        dto.Worktripgen = (WorktripgenModelDto)field;

        return dto;
    }
}
