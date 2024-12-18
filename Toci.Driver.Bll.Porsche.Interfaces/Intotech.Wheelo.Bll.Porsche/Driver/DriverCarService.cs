﻿using Intotech.Common;
using Intotech.Common.Bll.ComplexResponses;
using Intotech.Wheelo.Bll.Persistence.Interfaces;
using Intotech.Wheelo.Bll.Porsche.Interfaces.Driver;
using Intotech.Wheelo.Common.Interfaces;
using Intotech.Wheelo.Common;
using Toci.Driver.Database.Persistence.Models;
using Intotech.Wheelo.Bll.Models.Trip;

namespace Intotech.Wheelo.Bll.Porsche.Driver;

public class DriverCarService : IDriverCarService
{
    protected IAccountsCarsLocationLogic VAccountsCarsLocationLogic;
    protected ICarLogic CarLogic;

    public DriverCarService(IAccountsCarsLocationLogic vaccountsCarsLocationLogic, ICarLogic carLogic)
    {
        VAccountsCarsLocationLogic = vaccountsCarsLocationLogic;
        CarLogic = carLogic;
    }

    public virtual ReturnedResponse<Accountscarslocation> GetDriverCarInfo(int accountId)
    {
        Accountscarslocation result = VAccountsCarsLocationLogic.Select(m => m.Idaccount == accountId).FirstOrDefault();

        if (result == null)
        {
            return new ReturnedResponse<Accountscarslocation>(null, I18nTranslation.Translation(I18nTags.WrongData), false, ErrorCodes.DataIntegrityViolated);
        }

        return new ReturnedResponse<Accountscarslocation>(result, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
    }

    public virtual ReturnedResponse<bool> SetDriverCar(CarDto carData)
    {
        Car car =  DtoModelMapper.Map<Car, CarDto>(carData);

        int result = CarLogic.Insert(car).Id;

        return new ReturnedResponse<bool>(true, I18nTranslation.Translation(I18nTags.Success), true, ErrorCodes.Success);
    }
}