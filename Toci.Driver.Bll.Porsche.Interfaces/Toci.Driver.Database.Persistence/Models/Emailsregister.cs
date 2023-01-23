using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Emailsregister
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public int? Verificationcode { get; set; }
        public bool? Isverified { get; set; }
    }
}
