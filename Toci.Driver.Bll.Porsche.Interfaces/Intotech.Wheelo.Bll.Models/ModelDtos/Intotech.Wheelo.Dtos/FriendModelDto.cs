using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class FriendModelDto : DtoBase<Friend, FriendModelDto>
{
    public int Id { get; set; }
    public int Idaccount { get; set; }
    public int Idfriend { get; set; }
    public int Method { get; set; }
    public DateTime Createdat { get; set; }
}
