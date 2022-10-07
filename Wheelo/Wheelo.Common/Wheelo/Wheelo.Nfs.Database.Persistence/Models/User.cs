using System;
using System.Collections.Generic;

#nullable disable

namespace Wheelo.Nfs.Database.Persistence.Models
{
    public partial class User
    {
        public User()
        {
            Cars = new HashSet<Car>();
            FriendIdfriendNavigations = new HashSet<Friend>();
            FriendIduserNavigations = new HashSet<Friend>();
            FriendsuggestionIdsuggestedNavigations = new HashSet<Friendsuggestion>();
            FriendsuggestionIduserNavigations = new HashSet<Friendsuggestion>();
            InvitationIdinvitedNavigations = new HashSet<Invitation>();
            InvitationIduserNavigations = new HashSet<Invitation>();
            UserscollocationIdcollocatedNavigations = new HashSet<Userscollocation>();
            UserscollocationIduserNavigations = new HashSet<Userscollocation>();
            Userslocations = new HashSet<Userslocation>();
            Usersworktimes = new HashSet<Usersworktime>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime? Datewhen { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Friend> FriendIdfriendNavigations { get; set; }
        public virtual ICollection<Friend> FriendIduserNavigations { get; set; }
        public virtual ICollection<Friendsuggestion> FriendsuggestionIdsuggestedNavigations { get; set; }
        public virtual ICollection<Friendsuggestion> FriendsuggestionIduserNavigations { get; set; }
        public virtual ICollection<Invitation> InvitationIdinvitedNavigations { get; set; }
        public virtual ICollection<Invitation> InvitationIduserNavigations { get; set; }
        public virtual ICollection<Userscollocation> UserscollocationIdcollocatedNavigations { get; set; }
        public virtual ICollection<Userscollocation> UserscollocationIduserNavigations { get; set; }
        public virtual ICollection<Userslocation> Userslocations { get; set; }
        public virtual ICollection<Usersworktime> Usersworktimes { get; set; }
    }
}
