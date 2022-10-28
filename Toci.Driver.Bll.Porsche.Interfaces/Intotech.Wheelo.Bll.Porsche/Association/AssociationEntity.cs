using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Bll.Porsche.Interfaces.Association;
using Toci.Driver.Database.Persistence.Models;

namespace Toci.Driver.Bll.Porsche.Association
{
    public class AssociationEntity : IAssociationEntity
    {
        public Worktrip Current { get; set; }
        public List<Worktrip> Associatated { get ; set ; }

    }
}
