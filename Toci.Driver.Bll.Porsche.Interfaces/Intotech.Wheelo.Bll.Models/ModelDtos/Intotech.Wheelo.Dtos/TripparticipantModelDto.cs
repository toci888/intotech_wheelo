﻿using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class TripparticipantModelDto : DtoBase<Tripparticipant, TripparticipantModelDto>
{
    public int Id { get; set; }
    public int Idtrip { get; set; }
    public int Idaccount { get; set; }
    public Boolean Isconfirmed { get; set; }
    public Boolean Isoccasion { get; set; }
    public DateTime Createdat { get; set; }
}
