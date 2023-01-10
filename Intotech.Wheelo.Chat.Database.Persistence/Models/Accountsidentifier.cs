using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Chat.Database.Persistence.Models;

public partial class Accountsidentifier
{
    public int Id { get; set; }

    public int Idroom { get; set; }

    public string Email { get; set; } = null!;

    public DateTime? Createdat { get; set; }

    public virtual Room IdroomNavigation { get; set; } = null!;
}
