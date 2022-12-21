using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Social.Database.Persistence.Models;

public partial class Expense
{
    public int Id { get; set; }

    public int Idaccount { get; set; }

    public int Kind { get; set; }

    public double Amount { get; set; }

    public DateTime? Createdat { get; set; }
}
