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
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 2, Idtrip = 2, Isoccasion = false });
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 3, Idtrip = 3, Isoccasion = false });
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 1, Idtrip = 4, Isoccasion = false });
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 2, Idtrip = 5, Isoccasion = false });
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 3, Idtrip = 6, Isoccasion = false });
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 1, Idtrip = 7, Isoccasion = false });
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 2, Idtrip = 8, Isoccasion = false });
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 3, Idtrip = 9, Isoccasion = false });
//9 ModelówEntities
            InsertCollection(ModelsEntities);
        }
    }
}
