usignsad

asdasdasd

public class WorktripgenDtoLogic : DtoLogicBase<WorktripgenModelDto, Worktripgen, IWorktripgenLogic, WorktripgenDto, List<Worktripgen>, List<WorktripgenModelDto>>
{
    public WorktripgenDtoLogic(IWorktripgenLogic worktripgenlogic) 
        : base(worktripgenlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Worktripgen = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Worktripgen,WorktripgenDto> GetDtoModelField(WorktripgenDto dto)
    {
       return dto.Worktripgen;
    }

    protected override WorktripgenDto FillEntity(WorktripgenDto dto, DtoBase<Worktripgen> field)
    {
        dto.Worktripgen = (WorktripgenModelDto)field;

        return dto;
    }
}
