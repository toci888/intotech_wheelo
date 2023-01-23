using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Notuser
    {
        public int Id { get; set; }
        public string Searchid { get; set; } = null!;
    }
}
