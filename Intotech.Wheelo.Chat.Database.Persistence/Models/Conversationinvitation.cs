using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Chat.Database.Persistence.Models;

public partial class Conversationinvitation
{
    public int Id { get; set; }

    public int Idaccount { get; set; }

    public int Idaccountinvited { get; set; }

    public string Roomid { get; set; } = null!;

    public DateTime? Createdat { get; set; }
}
