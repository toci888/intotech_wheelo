using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Dictionaries.Database.Persistence.Models;

public partial class Colour
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Rgb { get; set; }
}
