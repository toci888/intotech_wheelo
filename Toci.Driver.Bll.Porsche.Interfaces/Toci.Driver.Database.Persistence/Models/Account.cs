using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Account
    {
        public Account()
        {
            AccountscollocationIdaccountNavigations = new HashSet<Accountscollocation>();
            AccountscollocationIdcollocatedNavigations = new HashSet<Accountscollocation>();
            Accountslocations = new HashSet<Accountslocation>();
            Accountsworktimes = new HashSet<Accountsworktime>();
            Cars = new HashSet<Car>();
            FriendIdaccountNavigations = new HashSet<Friend>();
            FriendIdfriendNavigations = new HashSet<Friend>();
            FriendsuggestionIdaccountNavigations = new HashSet<Friendsuggestion>();
            FriendsuggestionIdsuggestedNavigations = new HashSet<Friendsuggestion>();
            InvitationIdaccountNavigations = new HashSet<Invitation>();
            InvitationIdinvitedNavigations = new HashSet<Invitation>();
            Worktrips = new HashSet<Worktrip>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int? Emailconfirmed { get; set; }
        public int? Idgeographicregion { get; set; }
        public DateTime? Createdat { get; set; }
        public int Idrole { get; set; }
        public string? Token { get; set; }

        public virtual Geographicregion? IdgeographicregionNavigation { get; set; }
        public virtual Role IdroleNavigation { get; set; } = null!;
        public virtual ICollection<Accountscollocation> AccountscollocationIdaccountNavigations { get; set; }
        public virtual ICollection<Accountscollocation> AccountscollocationIdcollocatedNavigations { get; set; }
        public virtual ICollection<Accountslocation> Accountslocations { get; set; }
        public virtual ICollection<Accountsworktime> Accountsworktimes { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Friend> FriendIdaccountNavigations { get; set; }
        public virtual ICollection<Friend> FriendIdfriendNavigations { get; set; }
        public virtual ICollection<Friendsuggestion> FriendsuggestionIdaccountNavigations { get; set; }
        public virtual ICollection<Friendsuggestion> FriendsuggestionIdsuggestedNavigations { get; set; }
        public virtual ICollection<Invitation> InvitationIdaccountNavigations { get; set; }
        public virtual ICollection<Invitation> InvitationIdinvitedNavigations { get; set; }
        public virtual ICollection<Worktrip> Worktrips { get; set; }
    }
}
