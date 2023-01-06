using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Chat.Database.Persistence.Models;

public partial class Room
{
    public int Id { get; set; }

    public string Roomid { get; set; } = null!;

    public int Ownerid { get; set; }

    public string? Roomname { get; set; }

    public DateTime? Createdat { get; set; }
}
