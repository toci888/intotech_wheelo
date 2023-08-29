using Intotech.Common.Bll.Interfaces;
using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models;

public partial class Occupation : ModelBase
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Accountmetadatum> Accountmetadata { get; set; } = new List<Accountmetadatum>();

    public virtual ICollection<Occupationsmokercrat> Occupationsmokercrats { get; set; } = new List<Occupationsmokercrat>();
}
