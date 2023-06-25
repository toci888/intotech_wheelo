﻿using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class FriendsuggestionModelDto : DtoBase<Friendsuggestion, FriendsuggestionModelDto>
{
    public int Id { get; set; }
    public int Idaccount { get; set; }
    public int Idsuggested { get; set; }
    public int Idsuggestedfriend { get; set; }
    public DateTime Createdat { get; set; }
}
