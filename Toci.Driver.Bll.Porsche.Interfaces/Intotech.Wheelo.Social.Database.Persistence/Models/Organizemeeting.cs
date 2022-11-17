using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Social.Database.Persistence.Models;

public partial class Organizemeeting
{
    public int Id { get; set; }

    public int Idgroups { get; set; }

    public DateTime Meetingdate { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? Createdat { get; set; }

    public virtual Group IdgroupsNavigation { get; set; } = null!;
}
