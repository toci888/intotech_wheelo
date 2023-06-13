﻿using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class AccountscollocationModelDto : DtoBase<Accountscollocation>
{
    public int Id { get; set; }
    public int Idaccount { get; set; }
    public int Idcollocated { get; set; }
    public Decimal Distancefrom { get; set; }
    public Decimal Distanceto { get; set; }
    public DateTime Createdat { get; set; }
}
