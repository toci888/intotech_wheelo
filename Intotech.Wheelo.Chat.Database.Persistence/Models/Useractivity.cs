using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Chat.Database.Persistence.Models;

public partial class Useractivity
{
    public int Id { get; set; }

    public int Idaccount { get; set; }

    public DateTime? Connectedfrom { get; set; }

    public DateTime? Connectedto { get; set; }

    public DateTime? Createdat { get; set; }
}
