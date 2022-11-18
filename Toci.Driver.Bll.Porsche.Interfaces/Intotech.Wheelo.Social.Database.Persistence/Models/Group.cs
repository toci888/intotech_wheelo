using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Social.Database.Persistence.Models;

public partial class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Privacy { get; set; }

    public int Idaccountcreated { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual ICollection<Groupmember> Groupmembers { get; } = new List<Groupmember>();

    public virtual ICollection<Groupspost> Groupsposts { get; } = new List<Groupspost>();

    public virtual ICollection<Meetingskippedaccount> Meetingskippedaccounts { get; } = new List<Meetingskippedaccount>();

    public virtual ICollection<Organizemeeting> Organizemeetings { get; } = new List<Organizemeeting>();
}
