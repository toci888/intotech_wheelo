using Intotech.Common.Bll.Interfaces;
using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models;

public partial class Trip : ModelBase
{
    public int Id { get; set; }

    public int Idinitiatoraccount { get; set; }

    public int Idworktrip { get; set; }

    public DateOnly? Tripdate { get; set; }

    public bool? Iscurrent { get; set; }

    public TimeOnly? Fromhour { get; set; }

    public TimeOnly? Tohour { get; set; }

    public string? Summary { get; set; }

    public DateTime? Createdat { get; set; }

    public int? Leftseats { get; set; }

    public virtual Account IdinitiatoraccountNavigation { get; set; } = null!;

    public virtual Worktripgen IdworktripNavigation { get; set; } = null!;

    public virtual ICollection<Tripparticipant> Tripparticipants { get; set; } = new List<Tripparticipant>();
}
