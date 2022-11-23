using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Statisticstrip
    {
        public int Id { get; set; }
        public DateOnly? Tripdate { get; set; }
        public int Tripcars { get; set; }
        public int Trippeople { get; set; }
        public int? Idgeographicregion { get; set; }

        public virtual Geographicregion? IdgeographicregionNavigation { get; set; }
    }
}
