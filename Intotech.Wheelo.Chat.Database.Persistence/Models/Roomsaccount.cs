﻿using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Chat.Database.Persistence.Models;

public partial class Roomsaccount
{
    public int Id { get; set; }

    public int Idmember { get; set; }

    public string Roomid { get; set; } = null!;

    public DateTime? Createdat { get; set; }
}
