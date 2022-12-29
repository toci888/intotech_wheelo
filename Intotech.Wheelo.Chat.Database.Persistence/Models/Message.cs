using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Chat.Database.Persistence.Models;

public partial class Message
{
    public int Id { get; set; }

    public int Idauthor { get; set; }

    public string Roomid { get; set; } = null!;

    public string Message1 { get; set; } = null!;

    public DateTime? Createdat { get; set; }
}
