using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Vcarowner
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Registrationplate { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int? Availableseats { get; set; }
        public string? Colour { get; set; }
        public string? Rgb { get; set; }
    }
}
