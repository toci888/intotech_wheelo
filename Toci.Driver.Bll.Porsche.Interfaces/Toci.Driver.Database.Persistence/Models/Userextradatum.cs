using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Userextradatum
    {
        public int Id { get; set; }
        public int? Idoauthparties { get; set; }
        public string? Token { get; set; }
        public string? Tokendatajson { get; set; }
        public DateTime? Createdat { get; set; }

        public virtual Oauthparty? IdoauthpartiesNavigation { get; set; }
    }
}
