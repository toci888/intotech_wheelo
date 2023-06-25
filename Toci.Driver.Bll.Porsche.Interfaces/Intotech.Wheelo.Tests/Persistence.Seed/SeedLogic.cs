using Intotech.Common.Bll.Seed;
using Intotech.Common.Tests;
using Microsoft.EntityFrameworkCore;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed;

[TestClass]
public abstract class SeedLogic<TModel> : SeedBase<TModel> where TModel : class
{
    protected int AccountIdOffset = 1000000000;
    protected List<TModel> ModelsEntities = new List<TModel>();
    protected override DbContext GetEfHandle()
    {

            return new IntotechWheeloContext();

    }
}
