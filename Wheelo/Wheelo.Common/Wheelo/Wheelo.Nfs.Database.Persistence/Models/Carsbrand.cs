using System;
using System.Collections.Generic;

#nullable disable

namespace Wheelo.Nfs.Database.Persistence.Models
{
    public partial class Carsbrand
    {
        public Carsbrand()
        {
            Cars = new HashSet<Car>();
            Carsmodels = new HashSet<Carsmodel>();
        }

        public int Id { get; set; }
        public string Brand { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Carsmodel> Carsmodels { get; set; }
    }
}
