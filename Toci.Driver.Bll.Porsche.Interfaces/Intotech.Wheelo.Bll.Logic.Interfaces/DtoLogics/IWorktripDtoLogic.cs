using Intotech.Common.Bll.Interfaces.ChorDtoBll;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Common.Bll.ChorDtoBll;
using Toci.Driver.Database.Persistence.Models;


namespace Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;

   public interface IWorktripDtoLogic : IDtoLogicBase<WorktripModelDto, Worktrip, WorktripDto, List<Worktrip>, List<WorktripModelDto>>
    {

    }
