usignsad

asdasdasd

public class WorktripDtoLogic : DtoLogicBase<WorktripModelDto, Worktrip, IWorktripLogic, WorktripDto, List<Worktrip>, List<WorktripModelDto>>
{
    public WorktripDtoLogic(IWorktripLogic worktriplogic) 
        : base(worktriplogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Worktrip = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Worktrip,WorktripDto> GetDtoModelField(WorktripDto dto)
    {
       return dto.Worktrip;
    }

    protected override WorktripDto FillEntity(WorktripDto dto, DtoBase<Worktrip> field)
    {
        dto.Worktrip = (WorktripModelDto)field;

        return dto;
    }
}
