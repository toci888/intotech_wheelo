public class WorktripgenModelDto
{
    public Int32 Id { get; set; }
    public Int32 Idaccount { get; set; }
    public String Searchid { get; set; }
    public Double Latitudefrom { get; set; }
    public Double Longitudefrom { get; set; }
    public Double Latitudeto { get; set; }
    public Double Longitudeto { get; set; }
    public Int32 Idgeographiclocationfrom { get; set; }
    public Int32 Idgeographiclocationto { get; set; }
    public String Streetfrom { get; set; }
    public String Streetto { get; set; }
    public String Cityfrom { get; set; }
    public String Cityto { get; set; }
    public String Postcodefrom { get; set; }
    public String Postcodeto { get; set; }
    public TimeOnly Fromhour { get; set; }
    public TimeOnly Tohour { get; set; }
    public Double Acceptabledistance { get; set; }
    public Int32 Driverpassenger { get; set; }
    public DateTime Createdat { get; set; }
}
