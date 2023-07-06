using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;


namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class PushtokenModelDto : DtoCollectionBase<Pushtoken, PushtokenModelDto, List<Pushtoken>, List<PushtokenModelDto>>
{
    public int Id { get; set; }
    public int Idaccount { get; set; }
    public string Token { get; set; }
    public DateTime Createdat { get; set; }
}
