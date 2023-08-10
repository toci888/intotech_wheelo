using Intotech.Common.Bll.Interfaces.ChorDtoBll;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Common.Bll.ChorDtoBll;
using Toci.Driver.Database.Persistence.Models;


namespace Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;

   public interface IColourDtoLogic : IDtoLogicBase<ColourModelDto, Colour, ColourDto, List<Colour>, List<ColourModelDto>>
    {

    }
