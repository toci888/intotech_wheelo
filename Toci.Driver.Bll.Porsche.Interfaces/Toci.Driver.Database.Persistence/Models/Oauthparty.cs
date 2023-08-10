using Intotech.Common.Bll.Interfaces; 
using System;
using System.Collections.Generic;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class Oauthparty : ModelBase
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
