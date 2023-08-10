using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Bll.Interfaces;
using Intotech.Wheelo.Bll.Models.Dtos;

namespace Toci.Driver.Bll.Porsche.Interfaces.Services;

public interface ICarService : IService
{
    public ReturnedResponse<CarDto> AddCar(CarDto carDto);
    public ReturnedResponse<bool> DeleteCar(CarDto carDto);
    public ReturnedResponse<CarDto> UpdateCar(CarDto carDto);
    public ReturnedResponse<CarDto> GetCar(int id);
    public ReturnedResponse<List<CarDto>> GetCars(int accountId);
}