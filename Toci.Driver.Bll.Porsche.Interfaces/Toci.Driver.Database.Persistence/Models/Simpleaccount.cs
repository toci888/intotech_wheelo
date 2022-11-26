using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Simpleaccount
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Password { get; set; }
        public int? Verificationcode { get; set; }
    }
}
