using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class AccountModelDto : DtoBase<Toci.Driver.Database.Persistence.Models.Account>
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Password { get; set; }
    public int Verificationcode { get; set; }
    public DateTime Verificationcodevalid { get; set; }
    public int Idrole { get; set; }
    public Boolean Emailconfirmed { get; set; }
    public Boolean Allowsnotifications { get; set; }
    public string Image { get; set; }
    public string Phonenumber { get; set; }
    public string Refreshtoken { get; set; }
    public DateTime Refreshtokenvalid { get; set; }
    public DateTime Createdat { get; set; }
    public Accountmode Accountmode { get; set; }
}
