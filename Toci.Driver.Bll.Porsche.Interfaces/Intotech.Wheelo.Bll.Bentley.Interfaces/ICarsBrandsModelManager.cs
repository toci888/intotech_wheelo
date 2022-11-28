using Intotech.Common.Bll.ComplexResponses;
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
        ReturnedResponse<List<Carsbrand>> GetCarsBrandsForWildcard(string beginning);

        ReturnedResponse<List<Carsmodel>> GetModelsForBrandForWildcard(int carBrand, string beginning);
    }
}
