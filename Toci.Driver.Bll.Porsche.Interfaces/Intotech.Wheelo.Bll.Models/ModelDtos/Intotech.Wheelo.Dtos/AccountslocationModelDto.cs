public class AccountslocationModelDto
{
    public Int32 Id { get; set; }
    public Int32 Idaccounts { get; set; }
    public Decimal Latitudefrom { get; set; }
    public Decimal Longitudefrom { get; set; }
    public Decimal Latitudeto { get; set; }
    public Decimal Longitudeto { get; set; }
    public String Streetfrom { get; set; }
    public String Streetto { get; set; }
    public String Cityfrom { get; set; }
    public String Cityto { get; set; }
    public DateTime Createdat { get; set; }
}
