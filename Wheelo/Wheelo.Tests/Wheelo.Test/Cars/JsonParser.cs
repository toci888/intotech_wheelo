using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Wheelo.Test.Cars
{
    public class JsonParser
    {
        public Dictionary<string, List<CarEntity>> translate(string json)
        {
            Dictionary<string, List<CarEntity>> result = new Dictionary<string, List<CarEntity>>();

            List<CarEntity> johnny = new List<CarEntity>();
            johnny = JsonSerializer.Deserialize<List<CarEntity>>(json);
            //??

            foreach (CarEntity car in johnny)
            {
                if (result.ContainsKey(car.make))
                {
                    result[car.make].Add(car);
                }
                else
                {
                    result.Add(car.make, new List<CarEntity>() { car });
                }
            }

            return result;
        }
        // [{"year": 2016, "id": 1, "horsepower": 201, "make": "acura", "model": "ilx", "price": 31890.0, "img_url": "http://ts2.mm.bing.net/th?id=OIP.M7656c6f6aaa4d51c3ddee4b1192adeeeH0&pid=15.1"}, 
    }
}
