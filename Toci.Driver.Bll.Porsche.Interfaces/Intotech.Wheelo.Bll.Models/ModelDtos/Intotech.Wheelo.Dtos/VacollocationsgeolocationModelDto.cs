public class VacollocationsgeolocationModelDto
{
    public Int32 Idaccount { get; set; }
    public Int32 Accountidcollocated { get; set; }
    public String Name { get; set; }
    public String Surname { get; set; }
    public String Namecollocated { get; set; }
    public String Surnamecollocated { get; set; }
    public Double Latitudefrom { get; set; }
    public Double Longitudefrom { get; set; }
    public Double Latitudeto { get; set; }
    public Double Longitudeto { get; set; }
    public TimeOnly Fromhour { get; set; }
    public TimeOnly Tohour { get; set; }
    public String Searchid { get; set; }
    public Int32 Isdriver { get; set; }
    public String Image { get; set; }
}
