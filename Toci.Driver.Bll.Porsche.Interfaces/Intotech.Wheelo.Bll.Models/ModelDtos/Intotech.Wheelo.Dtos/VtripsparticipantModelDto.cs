public class VtripsparticipantModelDto
{
    public String Name { get; set; }
    public String Surname { get; set; }
    public String Suggestedname { get; set; }
    public String Suggestedsurname { get; set; }
    public Int32 Accountid { get; set; }
    public Int32 Suggestedaccountid { get; set; }
    public DateOnly Tripdate { get; set; }
    public String Summary { get; set; }
    public Int32 Tripid { get; set; }
    public Boolean Iscurrent { get; set; }
    public TimeOnly Fromhour { get; set; }
    public TimeOnly Tohour { get; set; }
    public Int32 Leftseats { get; set; }
    public Boolean Isoccasion { get; set; }
}
