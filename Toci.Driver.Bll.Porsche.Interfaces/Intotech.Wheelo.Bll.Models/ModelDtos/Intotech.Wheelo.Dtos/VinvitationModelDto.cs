using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class VinvitationModelDto : DtoBase<Vinvitation, VinvitationModelDto>
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Invitedfirstname { get; set; }
    public string Invitedlastname { get; set; }
    public int Idaccount { get; set; }
    public int Idaccountinvited { get; set; }
    public DateTime Createdat { get; set; }
}
