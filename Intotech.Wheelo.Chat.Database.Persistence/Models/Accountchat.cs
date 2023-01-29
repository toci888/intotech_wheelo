using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Chat.Database.Persistence.Models;

public partial class Accountchat
{
    public int Id { get; set; }

    public string Memberemail { get; set; } = null!;

    public int Idaccount { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Pushtoken { get; set; }

    public bool? Hasmanyaccount { get; set; }
}
