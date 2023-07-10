﻿using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;


namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class OccupationModelDto : DtoCollectionBase<Occupation, OccupationModelDto, List<Occupation>, List<OccupationModelDto>>
{
    public int Id { get; set; }
    public string Name { get; set; }
}