using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic;

public class WorktripDtoLogic : DtoLogicBase<WorktripModelDto, Worktrip, IWorktripLogic, WorktripDto, List<Worktrip>, List<WorktripModelDto>>
{
    public WorktripDtoLogic(IWorktripLogic worktriplogic) 
        : base(worktriplogic, 
            (aDto, aModelDto) => { 
                aDto.Worktrip = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Worktrip,WorktripModelDto> GetDtoModelField(WorktripDto dto)
    {
       return dto.Worktrip;
    }

    protected override WorktripDto FillEntity(WorktripDto dto, WorktripModelDto  field)
    {
        dto.Worktrip = field;

        return dto;
    }    protected override WorktripDto FillEntity(WorktripDto dto, List<WorktripModelDto> field)
    {
        throw new NotImplementedException();
    }
}
