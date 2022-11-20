using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Social.Database.Persistence.Models;

public partial class Meetingskippedaccount
{
    public int Id { get; set; }

    public int Idgroups { get; set; }

    public int Idorganizemeeting { get; set; }

    public int Idaccount { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual Group IdgroupsNavigation { get; set; } = null!;

    public virtual Organizemeeting IdorganizemeetingNavigation { get; set; } = null!;
}
