using Intotech.Common.Bll.Interfaces;
using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models;

public partial class Vaworktripgengeolocation : ModelBase
{
    public int? Id { get; set; }

    public int? Accountid { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public double? Latitudefrom { get; set; }

    public double? Longitudefrom { get; set; }

    public double? Latitudeto { get; set; }

    public double? Longitudeto { get; set; }

    public TimeOnly? Fromhour { get; set; }

    public TimeOnly? Tohour { get; set; }

    public string? Searchid { get; set; }

    public int? Isdriver { get; set; }

    public string? Image { get; set; }
}
