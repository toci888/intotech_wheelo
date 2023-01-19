namespace Intotech.Wheelo.Common.Interfaces.Models;

public class FriendsDto
{
    public int idAccount { get; set; }
    public string Image { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public double Latitudefrom { get; set; }
    public double Longitudefrom { get; set; }
    public double Latitudeto { get; set; }
    public double Longitudeto { get; set; }
    public string Fromhour { get; set; }
    public string Tohour { get; set; }
    public string PhoneNumber { get; set; }

}