using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Social.Database.Persistence.Models;

public partial class Usercomment
{
    public int Id { get; set; }

    public int? Idusercomments { get; set; }

    public int Idaccountcommented { get; set; }

    public int Idaccountcommenting { get; set; }

    public string Comment { get; set; } = null!;

    public int Idcommenttypes { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual Commenttype IdcommenttypesNavigation { get; set; } = null!;

    public virtual Usercomment? IdusercommentsNavigation { get; set; }

    public virtual ICollection<Usercomment> InverseIdusercommentsNavigation { get; } = new List<Usercomment>();
}
