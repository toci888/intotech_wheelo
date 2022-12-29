using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Chat.Database.Persistence.Models;

public partial class Accountsidentifier
{
    public int Id { get; set; }

    public string Roomid { get; set; } = null!;

    public int Idaccount { get; set; }

    public DateTime? Createdat { get; set; }
}
