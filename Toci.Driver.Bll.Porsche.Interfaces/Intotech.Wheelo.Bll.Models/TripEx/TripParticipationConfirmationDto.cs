using Intotech.Common.Bll;

namespace Intotech.Wheelo.Bll.Models.TripEx;

public class TripParticipationConfirmationDto : DtoEntityBase
{
    public int InitiatorAccountId { get; set; }
    public int PassengerAccountId { get; set; }
}