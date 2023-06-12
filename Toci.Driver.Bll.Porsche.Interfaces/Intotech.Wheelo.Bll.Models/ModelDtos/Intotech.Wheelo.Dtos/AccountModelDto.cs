public class AccountModelDto
{
    public Int32 Id { get; set; }
    public String Email { get; set; }
    public String Name { get; set; }
    public String Surname { get; set; }
    public String Password { get; set; }
    public Int32 Verificationcode { get; set; }
    public DateTime Verificationcodevalid { get; set; }
    public Int32 Idrole { get; set; }
    public Boolean Emailconfirmed { get; set; }
    public Boolean Allowsnotifications { get; set; }
    public String Image { get; set; }
    public String Phonenumber { get; set; }
    public String Refreshtoken { get; set; }
    public DateTime Refreshtokenvalid { get; set; }
    public DateTime Createdat { get; set; }
}
