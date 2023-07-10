﻿using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;


namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class CarsmodelModelDto : DtoCollectionBase<Carsmodel, CarsmodelModelDto, List<Carsmodel>, List<CarsmodelModelDto>>
{
    public int Id { get; set; }
    public int Idcarsbrands { get; set; }
    public string Model { get; set; }
}