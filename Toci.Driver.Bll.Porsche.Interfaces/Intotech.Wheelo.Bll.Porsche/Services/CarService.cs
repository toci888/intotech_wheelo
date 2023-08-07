using Intotech.Common.Bll;
using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Interfaces;
using Intotech.Wheelo.Bll.Logic.Interfaces.DtoLogics;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Common;
using Intotech.Wheelo.Common.Interfaces;
using Toci.Driver.Bll.Porsche.Interfaces.Services;

namespace Intotech.Wheelo.Bll.Porsche.Services;

public class CarService : ServiceBaseEx, ICarService
{
    protected ICarDtoLogic CarDtoLogic;
    
    public CarService(ICarDtoLogic carDtoLogic, ITranslationEngineI18n translationEngineI18n) : base(translationEngineI18n)
    {
        CarDtoLogic = carDtoLogic;
    }
    
    public virtual ReturnedResponse<CarDto> AddCar(CarDto carDto)
    {
        CarDto result = CarDtoLogic.SetEntity(carDto);
        
        return new ReturnedResponse<CarDto>(result,
            I18nTranslationDep.Translation(I18nTags.Success), 
            true,
            ErrorCodes.Success);
    }

    public virtual ReturnedResponse<bool> DeleteCar(CarDto carDto)
    {
        throw new NotImplementedException();
    }

    public virtual ReturnedResponse<CarDto> UpdateCar(CarDto carDto)
    {
        throw new NotImplementedException();
    }

    public virtual ReturnedResponse<CarDto> GetCar(int id)
    {
        throw new NotImplementedException();
    }

    public virtual ReturnedResponse<List<CarDto>> GetCars(int accountId)
    {
        throw new NotImplementedException();
    }
}