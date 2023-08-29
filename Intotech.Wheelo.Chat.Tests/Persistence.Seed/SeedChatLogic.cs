using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Bll.Seed;
using Intotech.Common.Tests;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Intotech.Wheelo.Chat.Tests.Persistence.Seed;

[TestClass]
public abstract class SeedChatLogic<TModel> : SeedBase<TModel> where TModel : ModelBase
{
    protected override DbContext GetEfHandle()
    {

            return new IntotechWheeloChatContext(new DbContextOptions<IntotechWheeloChatContext>());

    }
}
