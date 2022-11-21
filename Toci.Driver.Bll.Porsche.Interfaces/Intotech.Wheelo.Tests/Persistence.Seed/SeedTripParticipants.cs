using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed
{
    public class SeedTripParticipants : SeedLogic<Tripparticipant>
    {
        public override void Insert()
        {
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 1, Idtrip = 1, Isoccasion = false });

            InsertCollection(ModelsEntities);
        }
    }
}
