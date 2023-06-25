using Intotech.Common.Bll.Interfaces; 
using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Carsmodel : ModelBase
    {
        public Carsmodel()
        {
            Cars = new HashSet<Car>();
        }

        public int Id { get; set; }
        public int Idcarsbrands { get; set; }
        public string? Model { get; set; }

        public virtual Carsbrand IdcarsbrandsNavigation { get; set; } = null!;
        public virtual ICollection<Car> Cars { get; set; }
    }
}
