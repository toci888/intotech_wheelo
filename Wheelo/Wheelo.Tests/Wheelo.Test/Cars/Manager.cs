using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Wheelo.Test.Cars
{
    [TestClass]
    public class Manager
    {
        [TestMethod]
        public void populatecars()
        {
            string path = @"C:\Users\tomek\Desktop\cars.txt";
            FileManager f = new FileManager();

            string x = f.ReadFile(path);

            JsonParser jsonParser = new JsonParser();
            DatabaseOperability d = new DatabaseOperability();
            d.Reptile(jsonParser.translate(x));


        }
    }
}
