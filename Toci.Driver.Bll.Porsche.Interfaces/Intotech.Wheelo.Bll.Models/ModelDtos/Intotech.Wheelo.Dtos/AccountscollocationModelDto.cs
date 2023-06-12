public class AccountscollocationModelDto
{
    public Int32 Id { get; set; }
    public Int32 Idaccount { get; set; }
    public Int32 Idcollocated { get; set; }
    public Decimal Distancefrom { get; set; }
    public Decimal Distanceto { get; set; }
    public DateTime Createdat { get; set; }
}
