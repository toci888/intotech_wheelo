using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class VfriendsuggestionModelDto : DtoBase<Vfriendsuggestion>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Suggestedname { get; set; }
    public string Suggestedsurname { get; set; }
    public int Accountid { get; set; }
    public int Suggestedaccountid { get; set; }
    public string Suggestedfriendname { get; set; }
    public string Suggestedfriendsurname { get; set; }
    public int Suggestedfriendid { get; set; }
}
