using Intotech.Common.Bll.Interfaces;
using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Social.Database.Persistence.Models;

public partial class Groupspostscomment : ModelBase
{
    public int Id { get; set; }

    public int? Idgroupspostscomments { get; set; }

    public int Idpostcommented { get; set; }

    public int Idaccountcommenting { get; set; }

    public string Comment { get; set; } = null!;

    public int Idcommenttypes { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual Commenttype IdcommenttypesNavigation { get; set; } = null!;

    public virtual Groupspostscomment? IdgroupspostscommentsNavigation { get; set; }

    public virtual Groupspost IdpostcommentedNavigation { get; set; } = null!;

    public virtual ICollection<Groupspostscomment> InverseIdgroupspostscommentsNavigation { get; } = new List<Groupspostscomment>();
}
