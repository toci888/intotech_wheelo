﻿using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Failedloginattempt
    {
        public int Id { get; set; }
        public int Idaccount { get; set; }
        public int Kind { get; set; }
        public DateTime Createdat { get; set; }

        public virtual Account IdaccountNavigation { get; set; } = null!;
    }
}
