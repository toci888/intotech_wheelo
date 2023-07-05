using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;


namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class NotuserModelDto : DtoCollectionBase<Notuser, NotuserModelDto, List<Notuser>, List<NotuserModelDto>>
{
    public int Id { get; set; }
    public string Searchid { get; set; }
}
