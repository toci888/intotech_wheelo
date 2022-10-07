using System;
using System.Collections.Generic;

#nullable disable

namespace Wheelo.Nfs.Database.Persistence.Models
{
    public partial class Carsmodel
    {
        public Carsmodel()
        {
            Cars = new HashSet<Car>();
        }

        public int Id { get; set; }
        public int Idcarsbrands { get; set; }
        public string Model { get; set; }

        public virtual Carsbrand IdcarsbrandsNavigation { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
