using Intotech.Common.Tests;
using Microsoft.EntityFrameworkCore;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed;

[TestClass]
public abstract class SeedLogic<TModel> : SeedBase<TModel> where TModel : class
{
    protected override DbContext GetEfHandle()
    {

            return new IntotechWheeloContext();

    }
}
