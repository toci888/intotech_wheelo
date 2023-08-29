using Intotech.Common.Bll.Interfaces;
using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models;

public partial class Geographicregion : ModelBase
{
    public int Id { get; set; }

    public int? Idparent { get; set; }

    public int? Idshit { get; set; }

    public string? Name { get; set; }

    public int? Nestlevel { get; set; }

    public virtual ICollection<Accountmetadatum> Accountmetadata { get; set; } = new List<Accountmetadatum>();

    public virtual Geographicregion? IdparentNavigation { get; set; }

    public virtual ICollection<Geographicregion> InverseIdparentNavigation { get; set; } = new List<Geographicregion>();

    public virtual ICollection<Statisticstrip> Statisticstrips { get; set; } = new List<Statisticstrip>();

    public virtual ICollection<Worktrip> WorktripIdgeographiclocationfromNavigations { get; set; } = new List<Worktrip>();

    public virtual ICollection<Worktrip> WorktripIdgeographiclocationtoNavigations { get; set; } = new List<Worktrip>();

    public virtual ICollection<Worktripgen> WorktripgenIdgeographiclocationfromNavigations { get; set; } = new List<Worktripgen>();

    public virtual ICollection<Worktripgen> WorktripgenIdgeographiclocationtoNavigations { get; set; } = new List<Worktripgen>();
}
