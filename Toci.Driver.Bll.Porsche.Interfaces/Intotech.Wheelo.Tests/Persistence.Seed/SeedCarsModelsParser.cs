using Intotech.Common.Tests;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
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
    public class SeedCarsModelsParser : SeedLogic<Carsmodel>
    {
        protected ICarsBrandLogic CarsLogic = new CarsBrandLogic();

        [TestMethod]
        public override void Insert()
        {
            List<Carsbrand> cars = CarsLogic.Select(m => true).ToList();
            List<Carsmodel> CarsmodelEntities = new List<Carsmodel>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(select));

            foreach (Carsbrand car in cars)
            {
                if (File.Exists("../../../../../SQL/CarsModelsXmls/" + car.Brand + ".txt"))
                {
                    string xmlCandidate = File.ReadAllText("../../../../../SQL/CarsModelsXmls/" + car.Brand + ".txt");

                    select resultXmlEntity = xmlSerializer.Deserialize(new FileStream("../../../../../SQL/CarsModelsXmls/" + car.Brand + ".txt", FileMode.Open)) as select;

                    foreach (selectOption carXml in resultXmlEntity.option)
                    {
                        CarsmodelEntities.Add(new Carsmodel() { Idcarsbrands = car.Id, Model = carXml.Value });
                    }
                }
            }

            InsertCollection(CarsmodelEntities);
        }
    }
}
