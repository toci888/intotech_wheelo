﻿using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;


namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class TripparticipantModelDto : DtoCollectionBase<Tripparticipant, TripparticipantModelDto, List<Tripparticipant>, List<TripparticipantModelDto>>
{
    public int Id { get; set; }
    public int Idtrip { get; set; }
    public int Idaccount { get; set; }
    public Boolean Isconfirmed { get; set; }
    public Boolean Isoccasion { get; set; }
    public DateTime Createdat { get; set; }
}
