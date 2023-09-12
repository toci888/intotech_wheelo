using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Bll.Seed;
using Intotech.Common.Tests;
using Intotech.Wheelo.Database;
using Microsoft.EntityFrameworkCore;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed;

[TestClass]
public abstract class SeedLogic<TModel> : SeedBase<TModel> where TModel : ModelBase
{
    protected int AccountIdOffset = 1000000000;
    protected List<TModel> ModelsEntities = new List<TModel>();

    public SeedLogic()
    {
        DbHandle = new DbHandleCriticalSectionIW<TModel>(() => null, "Host=localhost;Database=Intotech.Wheelo;Username=postgres;Password=beatka");

    }
    protected override DbContext GetEfHandle()
    {

            return new IntotechWheeloContext();

    }
}
