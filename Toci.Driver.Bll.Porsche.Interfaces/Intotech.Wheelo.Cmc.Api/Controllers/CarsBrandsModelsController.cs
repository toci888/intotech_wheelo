using Intotech.Common.Microservices;
using Intotech.Wheelo.Bll.Bentley.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Cmc.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CarsBrandsModelsController : ApiSimpleControllerBase<ICarsBrandsModelManager>
	{
		public CarsBrandsModelsController(ICarsBrandsModelManager logic) : base(logic)
		{
		}

		[HttpGet]
		[Route("get-cars-brands-for-wildcard")]
		public List<Carsbrand> GetCarsBrandsForWildcard(string beginning)
		{
			return Logic.GetCarsBrandsForWildcard(beginning);
		}
		//224

		[HttpGet]
		[Route("get-cars-models-for-wildcard")]
		public List<Carsmodel> GetCarsModelsForWildcard(int brandId, string beginning)
		{
			return Logic.GetModelsForBrandForWildcard(brandId, beginning);
		}
	}
}
