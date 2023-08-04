using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Common.Bll.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;


public class VfriendsuggestionModelDto : DtoModelBase
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
    public int Id { get; set; }
}
