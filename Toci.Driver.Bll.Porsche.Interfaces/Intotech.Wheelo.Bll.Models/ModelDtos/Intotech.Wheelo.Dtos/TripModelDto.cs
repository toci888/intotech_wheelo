public class TripModelDto
{
    public Int32 Id { get; set; }
    public Int32 Idinitiatoraccount { get; set; }
    public Int32 Idworktrip { get; set; }
    public DateOnly Tripdate { get; set; }
    public Boolean Iscurrent { get; set; }
    public TimeOnly Fromhour { get; set; }
    public TimeOnly Tohour { get; set; }
    public String Summary { get; set; }
    public DateTime Createdat { get; set; }
    public Int32 Leftseats { get; set; }
}
