using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Accountscarslocation
    {
        public int? Accountid { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Streetfrom { get; set; }
        public string? Streetto { get; set; }
        public string? Cityfrom { get; set; }
        public string? Cityto { get; set; }
        public string? Registrationplate { get; set; }
        public int? Availableseats { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Colour { get; set; }
        public string? Rgb { get; set; }
    }
}
