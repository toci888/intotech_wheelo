using Intotech.Common.Bll.Interfaces;
using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models;

public partial class Accountscollocation : ModelBase
{
    public int Id { get; set; }

    public int Idaccount { get; set; }

    public int Idcollocated { get; set; }

    public decimal? Distancefrom { get; set; }

    public decimal? Distanceto { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual Account IdaccountNavigation { get; set; } = null!;

    public virtual Account IdcollocatedNavigation { get; set; } = null!;
}
