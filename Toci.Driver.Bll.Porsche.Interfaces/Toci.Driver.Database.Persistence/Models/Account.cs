using Intotech.Common.Bll.Interfaces; 
using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Account : ModelBase
    {
        public Account()
        {
            Accountmetadata = new HashSet<Accountmetadatum>();
            AccountscollocationIdaccountNavigations = new HashSet<Accountscollocation>();
            AccountscollocationIdcollocatedNavigations = new HashSet<Accountscollocation>();
            Accountslocations = new HashSet<Accountslocation>();
            Accountsworktimes = new HashSet<Accountsworktime>();
            Cars = new HashSet<Car>();
            Failedloginattempts = new HashSet<Failedloginattempt>();
            FriendIdaccountNavigations = new HashSet<Friend>();
            FriendIdfriendNavigations = new HashSet<Friend>();
            FriendsuggestionIdaccountNavigations = new HashSet<Friendsuggestion>();
            FriendsuggestionIdsuggestedNavigations = new HashSet<Friendsuggestion>();
            FriendsuggestionIdsuggestedfriendNavigations = new HashSet<Friendsuggestion>();
            InvitationIdaccountNavigations = new HashSet<Invitation>();
            InvitationIdinvitedNavigations = new HashSet<Invitation>();
            Occupationsmokercrats = new HashSet<Occupationsmokercrat>();
            Passwordstrengths = new HashSet<Passwordstrength>();
            Pushtokens = new HashSet<Pushtoken>();
            Tripparticipants = new HashSet<Tripparticipant>();
            Trips = new HashSet<Trip>();
            Userextradata = new HashSet<Userextradatum>();
            Worktripgens = new HashSet<Worktripgen>();
        }

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

        public virtual Role? IdroleNavigation { get; set; }
        public virtual Accountmode? Accountmode { get; set; }
        public virtual ICollection<Accountmetadatum>? Accountmetadata { get; set; }
        public virtual ICollection<Accountscollocation> AccountscollocationIdaccountNavigations { get; set; }
        public virtual ICollection<Accountscollocation> AccountscollocationIdcollocatedNavigations { get; set; }
        public virtual ICollection<Accountslocation> Accountslocations { get; set; }
        public virtual ICollection<Accountsworktime> Accountsworktimes { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Failedloginattempt> Failedloginattempts { get; set; }
        public virtual ICollection<Friend> FriendIdaccountNavigations { get; set; }
        public virtual ICollection<Friend> FriendIdfriendNavigations { get; set; }
        public virtual ICollection<Friendsuggestion> FriendsuggestionIdaccountNavigations { get; set; }
        public virtual ICollection<Friendsuggestion> FriendsuggestionIdsuggestedNavigations { get; set; }
        public virtual ICollection<Friendsuggestion> FriendsuggestionIdsuggestedfriendNavigations { get; set; }
        public virtual ICollection<Invitation> InvitationIdaccountNavigations { get; set; }
        public virtual ICollection<Invitation> InvitationIdinvitedNavigations { get; set; }
        public virtual ICollection<Occupationsmokercrat> Occupationsmokercrats { get; set; }
        public virtual ICollection<Passwordstrength> Passwordstrengths { get; set; }
        public virtual ICollection<Pushtoken> Pushtokens { get; set; }
        public virtual ICollection<Tripparticipant> Tripparticipants { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
        public virtual ICollection<Userextradatum> Userextradata { get; set; }
        public virtual ICollection<Worktripgen> Worktripgens { get; set; }
    }
}
