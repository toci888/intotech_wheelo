using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Colour
    {
        public Colour()
        {
            Cars = new HashSet<Car>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Rgb { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
