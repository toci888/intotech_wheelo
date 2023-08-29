using Intotech.Common.Bll.Interfaces;
using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Chat.Database.Persistence.Models;

public partial class Connecteduser : ModelBase
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public DateTime? Createdat { get; set; }
}
