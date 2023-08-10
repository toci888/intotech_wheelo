using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Dictionaries.Database.Persistence.Models;

public partial class Carsmodel
{
    public int Id { get; set; }

    public int Idcarsbrands { get; set; }

    public string? Model { get; set; }

    public virtual Carsbrand IdcarsbrandsNavigation { get; set; } = null!;
}
