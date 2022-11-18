using Intotech.Common.Tests;
using Intotech.Wheelo.Social.Database.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed;

[TestClass]
public abstract class SeedSocialLogic<TModel> : SeedBase<TModel> where TModel : class
{
    protected override DbContext GetEfHandle()
    {

            return new IntotechWheeloSocialContext();

    }
}
