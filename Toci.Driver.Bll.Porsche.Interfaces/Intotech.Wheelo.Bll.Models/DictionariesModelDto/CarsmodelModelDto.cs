﻿using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Common.Bll.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.DictionariesModelDto;

public class CarsmodelModelDto : DtoModelBase// DtoCollectionBase<Carsmodel, CarsmodelModelDto, List<Carsmodel>, List<CarsmodelModelDto>>
{
    public int Id { get; set; }
    public int Idcarsbrands { get; set; }
    public string Model { get; set; }
}