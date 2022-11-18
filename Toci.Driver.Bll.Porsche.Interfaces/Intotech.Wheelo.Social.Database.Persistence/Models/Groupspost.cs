using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Social.Database.Persistence.Models;

public partial class Groupspost
{
    public int Id { get; set; }

    public int Idgroups { get; set; }

    public int Idaccount { get; set; }

    public string Content { get; set; } = null!;

    public DateTime? Createdat { get; set; }

    public virtual ICollection<Groupspostscomment> Groupspostscomments { get; } = new List<Groupspostscomment>();

    public virtual Group IdgroupsNavigation { get; set; } = null!;
}
