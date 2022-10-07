using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Car
    {
        public int Id { get; set; }
        public int Idusers { get; set; }
        public int Idcarsbrands { get; set; }
        public int Idcarsmodels { get; set; }
        public int Availableseats { get; set; }
        public DateTime? Datewhen { get; set; }

        public virtual Carsbrand IdcarsbrandsNavigation { get; set; }
        public virtual Carsmodel IdcarsmodelsNavigation { get; set; }
        public virtual User IdusersNavigation { get; set; }
    }
}
