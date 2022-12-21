using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Chat.Database.Persistence.Models;

public partial class Message
{
    public string Id { get; set; }

    public string Idauthor { get; set; }

    public string? Idroom { get; set; }

    public string Message1 { get; set; } = null!;

    public DateTime? Createdat { get; set; }

    public virtual Room? IdroomNavigation { get; set; }
}
