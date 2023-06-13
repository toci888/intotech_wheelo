using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class VtripsparticipantModelDto : DtoBase<Vtripsparticipant>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Suggestedname { get; set; }
    public string Suggestedsurname { get; set; }
    public int Accountid { get; set; }
    public int Suggestedaccountid { get; set; }
    public DateOnly Tripdate { get; set; }
    public string Summary { get; set; }
    public int Tripid { get; set; }
    public Boolean Iscurrent { get; set; }
    public TimeOnly Fromhour { get; set; }
    public TimeOnly Tohour { get; set; }
    public int Leftseats { get; set; }
    public Boolean Isoccasion { get; set; }
}
