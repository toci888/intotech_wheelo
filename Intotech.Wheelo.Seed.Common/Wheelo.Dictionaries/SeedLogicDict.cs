using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Bll.Seed;
using Intotech.Common.Tests;
using Intotech.Wheelo.Database;
using Intotech.Wheelo.Dictionaries.Database;
using Intotech.Wheelo.Dictionaries.Database.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Seed.Common;

public abstract class SeedLogicDict<TModel> : SeedBase<TModel> where TModel : ModelBase
{
    protected int AccountIdOffset = 1000000000;
    protected List<TModel> ModelsEntities = new List<TModel>();

    public SeedLogicDict()
    {
        DbHandle = new DbHandleCriticalSectionIWD<TModel>(() => null, "Host=localhost;Database=Intotech.Wheelo;Username=postgres;Password=beatka");

    }
    protected override DbContext GetEfHandle()
    {

            return new IntotechWheeloDictionariesContext();

    }
}
