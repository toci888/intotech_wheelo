using Intotech.Common.Bll.Seed;
using Intotech.Common.Tests;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Intotech.Wheelo.Chat.Tests.Persistence.Seed;

[TestClass]
public abstract class SeedChatLogic<TModel> : SeedBase<TModel> where TModel : class
{
    protected override DbContext GetEfHandle()
    {

            return new IntotechWheeloChatContext();

    }
}
