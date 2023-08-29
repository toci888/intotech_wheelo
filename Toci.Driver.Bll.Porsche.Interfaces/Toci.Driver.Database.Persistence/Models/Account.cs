using Intotech.Common.Bll.Interfaces;
using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models;

public partial class Account : ModelBase
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Password { get; set; }

    public int? Verificationcode { get; set; }

    public DateTime? Verificationcodevalid { get; set; }

    public int? Idrole { get; set; }

    public bool? Emailconfirmed { get; set; }

    public bool? Allowsnotifications { get; set; }

    public string? Image { get; set; }

    public string? Phonenumber { get; set; }

    public string? Refreshtoken { get; set; }

    public DateTime? Refreshtokenvalid { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual ICollection<Accountmetadatum> Accountmetadata { get; set; } = new List<Accountmetadatum>();

    public virtual Accountmode? Accountmode { get; set; }

    public virtual ICollection<Accountscollocation> AccountscollocationIdaccountNavigations { get; set; } = new List<Accountscollocation>();

    public virtual ICollection<Accountscollocation> AccountscollocationIdcollocatedNavigations { get; set; } = new List<Accountscollocation>();

    public virtual ICollection<Accountslocation> Accountslocations { get; set; } = new List<Accountslocation>();

    public virtual ICollection<Accountsworktime> Accountsworktimes { get; set; } = new List<Accountsworktime>();

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual ICollection<Failedloginattempt> Failedloginattempts { get; set; } = new List<Failedloginattempt>();

    public virtual ICollection<Friend> FriendIdaccountNavigations { get; set; } = new List<Friend>();

    public virtual ICollection<Friend> FriendIdfriendNavigations { get; set; } = new List<Friend>();

    public virtual ICollection<Friendsuggestion> FriendsuggestionIdaccountNavigations { get; set; } = new List<Friendsuggestion>();

    public virtual ICollection<Friendsuggestion> FriendsuggestionIdsuggestedNavigations { get; set; } = new List<Friendsuggestion>();

    public virtual ICollection<Friendsuggestion> FriendsuggestionIdsuggestedfriendNavigations { get; set; } = new List<Friendsuggestion>();

    public virtual Role? IdroleNavigation { get; set; }

    public virtual ICollection<Invitation> InvitationIdaccountNavigations { get; set; } = new List<Invitation>();

    public virtual ICollection<Invitation> InvitationIdinvitedNavigations { get; set; } = new List<Invitation>();

    public virtual ICollection<Occupationsmokercrat> Occupationsmokercrats { get; set; } = new List<Occupationsmokercrat>();

    public virtual ICollection<Passwordstrength> Passwordstrengths { get; set; } = new List<Passwordstrength>();

    public virtual ICollection<Pushtoken> Pushtokens { get; set; } = new List<Pushtoken>();

    public virtual ICollection<Tripparticipant> Tripparticipants { get; set; } = new List<Tripparticipant>();

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();

    public virtual ICollection<Userextradatum> Userextradata { get; set; } = new List<Userextradatum>();

    public virtual ICollection<Worktripgen> Worktripgens { get; set; } = new List<Worktripgen>();
}
