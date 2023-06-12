public class VfriendModelDto
{
    public Int32 Idaccount { get; set; }
    public String Name { get; set; }
    public String Surname { get; set; }
    public String Friendname { get; set; }
    public String Friendsurname { get; set; }
    public Int32 Friendidaccount { get; set; }
    public Int32 Method { get; set; }
    public Double Latitudefrom { get; set; }
    public Double Longitudefrom { get; set; }
    public Double Latitudeto { get; set; }
    public Double Longitudeto { get; set; }
    public TimeOnly Fromhour { get; set; }
    public TimeOnly Tohour { get; set; }
    public String Searchid { get; set; }
    public Int32 Driverpassenger { get; set; }
}
