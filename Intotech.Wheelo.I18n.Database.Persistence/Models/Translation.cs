using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.I18n.Database.Persistence.Models;

public partial class Translation
{
    public int Id { get; set; }

    public int? Idlanguages { get; set; }

    public int? Idtag { get; set; }

    public string? Content { get; set; }

    public virtual Language? IdlanguagesNavigation { get; set; }

    public virtual Tag? IdtagNavigation { get; set; }
}
