using Intotech.Common.Bll.ComplexResponses;
using Intotech.Common.Bll.Interfaces;
using Intotech.Wheelo.Bll.Models.TripEx;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.Interfaces.Driver;

public interface IDriverCarService : IService
{
    ReturnedResponse<Accountscarslocation> GetDriverCarInfo(int accountId);

    ReturnedResponse<bool> SetDriverCar(CarDto carData);
}