public class VaccountscollocationsworktripModelDto
{
    public String Name { get; set; }
    public String Surname { get; set; }
    public String Suggestedname { get; set; }
    public String Suggestedsurname { get; set; }
    public Int32 Accountid { get; set; }
    public Int32 Suggestedaccountid { get; set; }
    public Decimal Distancefrom { get; set; }
    public Decimal Distanceto { get; set; }
    public Double Latitudefrom { get; set; }
    public Double Longitudefrom { get; set; }
    public Double Latitudeto { get; set; }
    public Double Longitudeto { get; set; }
    public TimeOnly Fromhour { get; set; }
    public TimeOnly Tohour { get; set; }
}
