using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;


namespace Intotech.Wheelo.Bll.Logic;


public class WorktripgenDtoLogic : DtoLogicBase<WorktripgenModelDto, Worktripgen, IWorktripgenLogic, WorktripgenDto, List<Worktripgen>, List<WorktripgenModelDto>>, IWorktripgenDtoLogic
{
    public WorktripgenDtoLogic(IWorktripgenLogic worktripgenlogic) 
        : base(worktripgenlogic, 
            (aDto, aModelDto) => { 
                aDto.Worktripgen = aModelDto;
                return aDto;
            })
    {
    }

    protected override WorktripgenModelDto GetDtoModelField(WorktripgenDto dto)
    {
       return dto.Worktripgen;
    }

    protected override WorktripgenDto FillEntity(WorktripgenDto dto, WorktripgenModelDto  field)
    {
        dto.Worktripgen = field;

        return dto;
    }    protected override WorktripgenDto FillEntity(WorktripgenDto dto, List<WorktripgenModelDto> field)
    {
        throw new NotImplementedException();
    }
}
