using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;


namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class EmailsregisterModelDto : DtoCollectionBase<Emailsregister, EmailsregisterModelDto, List<Emailsregister>, List<EmailsregisterModelDto>>
{
    public int Id { get; set; }
    public string Email { get; set; }
    public int Verificationcode { get; set; }
    public Boolean Isverified { get; set; }
}
