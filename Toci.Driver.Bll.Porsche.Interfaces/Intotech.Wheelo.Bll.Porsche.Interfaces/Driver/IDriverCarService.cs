using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Models.Trip;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Porsche.Interfaces.Driver;

public interface IDriverCarService
{
    ReturnedResponse<Accountscarslocation> GetDriverCarInfo(int accountId);

    ReturnedResponse<bool> SetDriverCar(CarDto carData);
}