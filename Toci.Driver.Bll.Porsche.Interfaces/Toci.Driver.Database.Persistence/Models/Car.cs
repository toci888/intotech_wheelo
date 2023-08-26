using Intotech.Common.Bll.Interfaces;
using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models;

public partial class Car : ModelBase
{
    public int Id { get; set; }

    public int Idaccounts { get; set; }

    public int Idcarsbrands { get; set; }

    public int Idcarsmodels { get; set; }

    public int Idcolours { get; set; }

    public string? Registrationplate { get; set; }

    public int Availableseats { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual Account IdaccountsNavigation { get; set; } = null!;
}
