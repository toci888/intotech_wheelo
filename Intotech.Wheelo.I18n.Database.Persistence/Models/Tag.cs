using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.I18n.Database.Persistence.Models;

public partial class Tag
{
    public int Id { get; set; }

    public string? Tag1 { get; set; }

    public virtual ICollection<Translation> Translations { get; } = new List<Translation>();
}
