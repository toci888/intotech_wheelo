using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Oauthparty
    {
        public Oauthparty()
        {
            Userextradata = new HashSet<Userextradatum>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Userextradatum> Userextradata { get; set; }
    }
}
