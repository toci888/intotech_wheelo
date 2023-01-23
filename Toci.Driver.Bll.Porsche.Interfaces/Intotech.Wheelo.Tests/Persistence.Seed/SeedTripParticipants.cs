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
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 1 + AccountIdOffset, Idtrip = 1, Isoccasion = false });
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 2 + AccountIdOffset, Idtrip = 1, Isoccasion = false });
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 3 + AccountIdOffset, Idtrip = 1, Isoccasion = false });
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 4 + AccountIdOffset, Idtrip = 2, Isoccasion = false });
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 5 + AccountIdOffset, Idtrip = 2, Isoccasion = false });
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 6 + AccountIdOffset, Idtrip = 2, Isoccasion = false });
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 7 + AccountIdOffset, Idtrip = 3, Isoccasion = false });
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 8 + AccountIdOffset, Idtrip = 3, Isoccasion = false });
            ModelsEntities.Add(new Tripparticipant() { Idaccount = 9 + AccountIdOffset, Idtrip = 3, Isoccasion = false });

            int beginIdtrip = 4;

            for (int i = 0; i < 80; i++)
            {
                ModelsEntities.Add(new Tripparticipant() { Idaccount = 10 + i + AccountIdOffset, Idtrip = beginIdtrip, Isoccasion = false });

                if (i % 4 == 0)
                {
                    beginIdtrip++;
                }
            }
//9 ModelówEntities
            InsertCollection(ModelsEntities);
        }
    }
}
