namespace Intotech.Wheelo.Bll.Models.TripEx;

public class TripInitiatorDto
{
    public int Id { get; set; }
    public int Idinitiatoraccount { get; set; }
    public string InitiatorFirstName { get; set; }
    public string InitiatorLastName { get; set; }
    public int Idworktrip { get; set; }
    public DateOnly? Tripdate { get; set; }
    public bool? Iscurrent { get; set; }
    public TimeOnly? Fromhour { get; set; }
    public TimeOnly? Tohour { get; set; }
    public string? Summary { get; set; }
    public DateTime? Createdat { get; set; }
    public int? Leftseats { get; set; }
}