﻿using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;


namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class PasswordstrengthModelDto : DtoCollectionBase<Passwordstrength, PasswordstrengthModelDto, List<Passwordstrength>, List<PasswordstrengthModelDto>>
{
    public int Id { get; set; }
    public int Idaccount { get; set; }
    public int Level { get; set; }
}