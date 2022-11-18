using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Social.Database.Persistence.Models;

public partial class Commenttype
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Groupspostscomment> Groupspostscomments { get; } = new List<Groupspostscomment>();

    public virtual ICollection<Usercomment> Usercomments { get; } = new List<Usercomment>();
}
