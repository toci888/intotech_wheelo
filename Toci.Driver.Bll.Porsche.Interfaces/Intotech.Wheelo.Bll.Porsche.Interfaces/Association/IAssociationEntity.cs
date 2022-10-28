using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Toci.Driver.Bll.Porsche.Interfaces.Association
{
   public interface IAssociationEntity
    {
        Worktrip Current { get; set; }
        List<Worktrip> Associatated { get; set; }

    }
}
