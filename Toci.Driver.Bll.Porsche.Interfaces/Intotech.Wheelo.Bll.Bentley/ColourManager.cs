using Intotech.Wheelo.Bll.Bentley.Interfaces;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Bentley
{
    public class ColourManager : IColourManager
    {

        protected IColourLogic ColoursLogic;

        public ColourManager(IColourLogic coloursLogic)
        {
            ColoursLogic = coloursLogic;
        }

        public virtual List<Colour> GetColoursForWildcard(string beginning)
        {
            return ColoursLogic.Select(m => m.Name.StartsWith(beginning)).ToList();
        }
    }
}