using Intotech.Common.Bll.Interfaces;
using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models;

public partial class Vinvitation : ModelBase
{
    public int? Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Invitedfirstname { get; set; }

    public string? Invitedlastname { get; set; }

    public int? Idaccount { get; set; }

    public int? Idaccountinvited { get; set; }

    public DateTime? Createdat { get; set; }
}
