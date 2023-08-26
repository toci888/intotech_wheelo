using Intotech.Common.Bll.Interfaces;
using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models;

public partial class Notuser : ModelBase
{
    public int Id { get; set; }

    public string Searchid { get; set; } = null!;
}
