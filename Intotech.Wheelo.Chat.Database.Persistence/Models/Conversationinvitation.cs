using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Chat.Database.Persistence.Models;

public partial class Conversationinvitation
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Emailinvited { get; set; } = null!;

    public int Idroom { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual Room IdroomNavigation { get; set; } = null!;
}
