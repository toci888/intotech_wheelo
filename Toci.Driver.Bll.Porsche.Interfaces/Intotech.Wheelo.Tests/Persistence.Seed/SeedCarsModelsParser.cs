using Intotech.Common.Tests;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Tests.Persistence.Seed
{
    [TestClass]
    public class SeedCarsModelsParser : SeedLogic<Carsmodel>
    {
        protected ICarsbrandLogic CarsLogic = new CarsbrandLogic();

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

                    select resultXmlEntity = null;
                    FileStream stream = null;

                    try
                    {
                        //stream = new FileStream("../../../../../SQL/CarsModelsXmls/" + car.Brand + ".txt", FileMode.Open);
                        StringReader strRead = new StringReader(xmlCandidate);
                        resultXmlEntity = xmlSerializer.Deserialize(strRead) as select;
                    }
                    catch (Exception ex)
                    {
                        //string robbieMadeAMistake = File.ReadAllText("../../../../../SQL/CarsModelsXmls/" + car.Brand + ".txt");
                        xmlCandidate = "<select>" + xmlCandidate + "</select>";

                        StringReader strRead = new StringReader(xmlCandidate);

                        resultXmlEntity = xmlSerializer.Deserialize(strRead) as select;
                    }

                    foreach (selectOption carXml in resultXmlEntity.option)
                    {
                        CarsmodelEntities.Add(new Carsmodel() { Idcarsbrands = car.Id, Model = carXml.Value });
                    }
                }
                else
                {
                    Console.WriteLine(car.Brand + " ist nicht gefunden ! xd");
                }
            }

            InsertCollection(CarsmodelEntities);
        }
    }
}
