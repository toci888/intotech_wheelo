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
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 2, Idtrip = 1, Isoccasion = false });
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 3, Idtrip = 1, Isoccasion = false });
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 4, Idtrip = 2, Isoccasion = false });
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 5, Idtrip = 2, Isoccasion = false });
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 6, Idtrip = 2, Isoccasion = false });
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 7, Idtrip = 3, Isoccasion = false });
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 8, Idtrip = 3, Isoccasion = false });
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 9, Idtrip = 3, Isoccasion = false });
//9 ModelówEntities
            InsertCollection(ModelsEntities);
        }
    }
}
