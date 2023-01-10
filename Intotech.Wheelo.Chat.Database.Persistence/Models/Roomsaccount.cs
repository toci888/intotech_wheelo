using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Chat.Database.Persistence.Models;

public partial class Roomsaccount
{
    public int Id { get; set; }

    public string Memberemail { get; set; } = null!;

    public int Idroom { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual Room IdroomNavigation { get; set; } = null!;
}
