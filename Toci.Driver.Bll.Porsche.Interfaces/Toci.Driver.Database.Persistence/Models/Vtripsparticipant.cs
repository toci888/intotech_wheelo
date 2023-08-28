using Intotech.Common.Bll.Interfaces;
using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models;

public partial class Vtripsparticipant : ModelBase
{
    public int? Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Suggestedname { get; set; }

    public string? Suggestedsurname { get; set; }

    public int? Accountid { get; set; }

    public int? Suggestedaccountid { get; set; }

    public DateOnly? Tripdate { get; set; }

    public string? Summary { get; set; }

    public int? Tripid { get; set; }

    public bool? Iscurrent { get; set; }

    public TimeOnly? Fromhour { get; set; }

    public TimeOnly? Tohour { get; set; }

    public int? Leftseats { get; set; }

    public bool? Isoccasion { get; set; }
}
