public class TripparticipantModelDto
{
    public Int32 Id { get; set; }
    public Int32 Idtrip { get; set; }
    public Int32 Idaccount { get; set; }
    public Boolean Isconfirmed { get; set; }
    public Boolean Isoccasion { get; set; }
    public DateTime Createdat { get; set; }
}
