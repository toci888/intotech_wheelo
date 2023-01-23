﻿using Intotech.Common;
using Intotech.Wheelo.Chat.Database.Persistence.Models;

namespace Intotech.Wheelo.Chat.Tests.Persistence.Seed;

public class SeedRooms : SeedChatLogic<Room>
{
    public override void Insert()
    {
        List<Room> rooms = new List<Room>();

        for (int i = 0; i < 10; i++)
        {
            rooms.Add(new Room() { Roomname = "Bartek", Ownerid = "bzapart@gmail.com" });
            rooms.Add(new Room() { Roomname = "Kacper", Ownerid = "bartek@gg.pl" });
            rooms.Add(new Room() { Roomname = "Warrior", Ownerid = "warriorr@poczta.fm" });
        }

        InsertCollection(rooms);
    }
}