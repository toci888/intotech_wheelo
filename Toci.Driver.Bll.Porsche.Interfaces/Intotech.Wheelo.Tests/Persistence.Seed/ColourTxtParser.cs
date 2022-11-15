using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed
{
    [TestClass]
    public class ColourTxtParser : SeedLogic<Colour>
    {
        [TestMethod]
        public override void Insert()
        {
            InsertCollection(RunColourParsing());
        }


        public List<Colour> RunColourParsing()
        {
            string file = File.ReadAllText("../../../../../SQL/colours.txt");

            string[] coloursLines = file.Split("\n");

            List<Colour> colourDb = new List<Colour>();

            foreach (string colour in coloursLines)
            { 
                string[] singleColour = colour.Split("\t");

                if (singleColour.Length > 2)
                {
                    if (singleColour[2].StartsWith("#"))
                    {
                        colourDb.Add(new Colour() { Name = singleColour[0], Rgb = singleColour[2] }); ;
                    }
                }
            }

            return colourDb;
        }
    }
}
