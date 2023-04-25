using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed
{
    [TestClass]
    public class CarsXmlParser : SeedLogic<Carsbrand>
    {
        [TestMethod]
        public override void Insert()
        {
            InsertCollection(GetCarsFromXml());
        }

        protected List<Carsbrand> GetCarsFromXml()
        {
            List <Carsbrand> cars = new List<Carsbrand>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(select));

            select resultXmlEntity = xmlSerializer.Deserialize(new FileStream("../../SQL/morecars.txt", FileMode.Open)) as select;

            foreach (selectOption carXml in resultXmlEntity.option)
            {
                cars.Add(new Carsbrand() { Brand = carXml.Value });
            }

            return cars;
        }
    }
}
