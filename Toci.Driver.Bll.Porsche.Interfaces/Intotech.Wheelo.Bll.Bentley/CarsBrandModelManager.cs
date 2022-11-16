using Intotech.Wheelo.Bll.Bentley.Interfaces;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Bentley
{
    public class CarsBrandModelManager : ICarsBrandsModelManager
    {
        protected ICarsBrandLogic CarsBrandLogic;
        protected ICarsModelLogic CarsModelLogic;

        public CarsBrandModelManager(ICarsBrandLogic carsBrandLogic, ICarsModelLogic carsModelLogic)
        {
            CarsBrandLogic = carsBrandLogic;
            CarsModelLogic = carsModelLogic;
        }
        public virtual List<Carsbrand> GetCarsBrandsForWildcard(string beginning)
        {
            return CarsBrandLogic.Select(m => m.Brand.StartsWith(beginning)).ToList();
        }

        public virtual List<Carsmodel> GetModelsForBrandForWildcard(int carBrand, string beginning)
        {
            return CarsModelLogic.Select(m => m.Idcarsbrands == carBrand && m.Model.StartsWith(beginning)).ToList();
        }
    }
}
