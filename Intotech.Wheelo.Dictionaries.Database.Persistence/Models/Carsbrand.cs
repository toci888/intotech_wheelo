using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Dictionaries.Database.Persistence.Models;

public partial class Carsbrand
{
    public int Id { get; set; }

    public string? Brand { get; set; }

    public virtual ICollection<Carsmodel> Carsmodels { get; set; } = new List<Carsmodel>();
}
