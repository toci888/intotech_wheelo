using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class SimpleaccountModelDto : DtoBase<Simpleaccount, SimpleaccountModelDto>
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Password { get; set; }
    public int Verificationcode { get; set; }
}
