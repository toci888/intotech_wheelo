using Intotech.Common.Bll.Interfaces;
using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models;

public partial class Accountsworktime : ModelBase
{
    public int Id { get; set; }

    public int Idaccounts { get; set; }

    public TimeOnly? Workstarthour { get; set; }

    public TimeOnly? Workendhour { get; set; }

    public virtual Account IdaccountsNavigation { get; set; } = null!;
}
