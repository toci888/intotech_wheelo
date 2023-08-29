using Intotech.Wheelo.Chat.Database.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Chat.Database.Persistence.Extensions
{
    public static class DbContextExtensions
    {
        public static DbContextOptionsBuilder<IntotechWheeloChatContext> DbContextOptionsBuilder(this DbContextOptionsBuilder<IntotechWheeloChatContext> dbContextOptionsElement)
        {
            return dbContextOptionsElement;
        }
    }
}
