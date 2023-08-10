using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;


namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class ResetpasswordModelDto : DtoCollectionBase<Resetpassword, ResetpasswordModelDto, List<Resetpassword>, List<ResetpasswordModelDto>>
{
    public int Id { get; set; }
    public DateTime Createdat { get; set; }
    public string Email { get; set; }
    public int Verificationcode { get; set; }
}
