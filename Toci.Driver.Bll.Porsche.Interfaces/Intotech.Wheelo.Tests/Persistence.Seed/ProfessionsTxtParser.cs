﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed
{
    public class ProfessionsTxtParser : SeedLogic<Occupation>
    {
        private const string HerebyDoc = "Niniejszy dokument";

        public override void Insert()
        {
            string file = File.ReadAllText("../../../../../SQL/professions.txt");

            string[] occupationLines = file.Split("\n");

            foreach (string profession in occupationLines)
            {
                if (!profession.Contains(HerebyDoc))
                {
                    string[] elements = profession.Split(" ");
                }
            }

            InsertCollection(ModelsEntities);
        }
    }
}
