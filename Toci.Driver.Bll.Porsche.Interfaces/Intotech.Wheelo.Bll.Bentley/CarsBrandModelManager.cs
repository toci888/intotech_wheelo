using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Bentley.Interfaces;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Common;
using Intotech.Wheelo.Common.Interfaces;
using Npgsql;
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
        protected ICarsbrandLogic CarsBrandLogic;
        protected ICarsmodelLogic CarsModelLogic;

        public CarsBrandModelManager(ICarsbrandLogic carsBrandLogic, ICarsmodelLogic carsModelLogic)
        {
            CarsBrandLogic = carsBrandLogic;
            CarsModelLogic = carsModelLogic;
        }
        public virtual ReturnedResponse<List<Carsbrand>> GetCarsBrandsForWildcard(string beginning)
        {
            return new ReturnedResponse<List<Carsbrand>>(CarsBrandLogic.Select(m => m.Brand.ToLower().StartsWith(beginning.ToLower())).ToList(), I18nTranslationDep.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }

        public virtual ReturnedResponse<List<Carsmodel>> GetModelsForBrandForWildcard(int carBrand, string beginning)
        {
            return new ReturnedResponse<List<Carsmodel>>(CarsModelLogic.Select(m => m.Idcarsbrands == carBrand && m.Model.StartsWith(beginning)).ToList(), I18nTranslationDep.Translation(I18nTags.Success), true, ErrorCodes.Success);
        }
    }
}
