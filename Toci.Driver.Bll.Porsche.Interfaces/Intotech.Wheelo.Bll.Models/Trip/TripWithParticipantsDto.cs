using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.Trip;

public class TripWithParticipantsDto
{
    public int Id { get; set; }
    public int Idinitiatoraccount { get; set; }
    public int Idworktrip { get; set; }
    public DateOnly? Tripdate { get; set; }
    public bool? Iscurrent { get; set; }
    public TimeOnly? Fromhour { get; set; }
    public TimeOnly? Tohour { get; set; }
    public string? Summary { get; set; }
    public DateTime? Createdat { get; set; }
    public int? Leftseats { get; set; }
    public List<Vtripsparticipant> Participants { get; set; }

}