using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.Isfa;

public class VInvitationDto : Vinvitation
{
    public string InvitingImageUrl { get; set; }
    public string InvitedImageUrl { get; set; }
}