using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Social.Database.Persistence.Models;

public partial class Groupmember
{
    public int Id { get; set; }

    public int? Idgroups { get; set; }

    public int Idaccount { get; set; }

    public int Idaccountwhoadded { get; set; }

    public int Level { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual Group? IdgroupsNavigation { get; set; }
}
