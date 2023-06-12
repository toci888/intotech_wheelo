public class AccountroleModelDto
{
    public Int32 Id { get; set; }
    public String Name { get; set; }
    public String Surname { get; set; }
    public String Email { get; set; }
    public String Password { get; set; }
    public Boolean Emailconfirmed { get; set; }
    public String Refreshtoken { get; set; }
    public String Rolename { get; set; }
    public DateTime Refreshtokenvalid { get; set; }
    public Boolean Allowsnotifications { get; set; }
}
