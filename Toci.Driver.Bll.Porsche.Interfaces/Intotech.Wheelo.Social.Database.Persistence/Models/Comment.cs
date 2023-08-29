using Intotech.Common.Bll.Interfaces;
using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Social.Database.Persistence.Models;

public partial class Comment : ModelBase
{
    public int Id { get; set; }

    public int Idcommenttypes { get; set; }

    public virtual Commenttype IdcommenttypesNavigation { get; set; } = null!;
}
