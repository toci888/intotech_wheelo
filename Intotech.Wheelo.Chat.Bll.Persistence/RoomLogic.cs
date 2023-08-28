using Intotech.Wheelo.Chat.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Chat.Database.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Chat.Bll.Persistence
{
    public class RoomLogic : Logic<Room>, IRoomLogic
    {
        public RoomLogic(bool cs) : base(cs)
        {
        }
    }
}
