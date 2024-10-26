using Intotech.Common.Bll;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

namespace Intotech.Wheelo.Bll.Models.Dtos;

public class FriendsuggestionDto : DtoEntityBase
{
    public FriendsuggestionModelDto Friendsuggestion { get; set; }
}

public class CreateFriendSuggestionDto
{
    public int AccountId { get; set; }
    public int SuggestedFriendId { get; set; }
}

public class UpdateFriendSuggestionDto
{
    public int Id { get; set; } // ID of the friend suggestion to update
    public int SuggestedFriendId { get; set; }
}

public class DeleteFriendSuggestionDto
{
    public int Id { get; set; } // ID of the friend suggestion to delete
}