using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Bll.Seed;
using Intotech.Common.Tests;
using Intotech.Wheelo.Chat.Database;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
using Intotech.Wheelo.Database;
using Microsoft.EntityFrameworkCore;

namespace Intotech.Wheelo.Chat.Tests.Persistence.Seed;

[TestClass]
public abstract class SeedChatLogic<TModel> : SeedBase<TModel> where TModel : ModelBase
{
    public SeedChatLogic()
    {

            DbHandle = new DbHandleCriticalSectionIWC<TModel>(() => null, "Host=localhost;Database=Intotech.Wheelo;Username=postgres;Password=beatka");
        
    }
    protected override DbContext GetEfHandle()
    {

            return new IntotechWheeloChatContext(new DbContextOptions<IntotechWheeloChatContext>());

    }
}
