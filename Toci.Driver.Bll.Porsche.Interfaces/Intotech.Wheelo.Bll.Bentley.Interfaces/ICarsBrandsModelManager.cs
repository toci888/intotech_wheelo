using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Bentley.Interfaces
{
    public interface ICarsBrandsModelManager
    {
        List<Carsbrand> GetCarsBrandsForWildcard(string beginning);

        List<Carsmodel> GetModelsForBrandForWildcard(int carBrand, string beginning);
    }
}
