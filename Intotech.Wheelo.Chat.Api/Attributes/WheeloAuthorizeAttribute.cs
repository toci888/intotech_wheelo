using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;


namespace Intotech.Wheelo.Chat.Api.Attributes;

public class WheeloAuthorizeAttribute : AuthorizeAttribute
{
    public override bool Match(object? obj)
    {
        return base.Match(obj);
    }

    public override bool IsDefaultAttribute()
    {
        return base.IsDefaultAttribute();
    }
}