//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Toci.Driver.Dal.Invitation.Interfaces
{
    using System;
    using System.Collections.Generic;
    
    public partial class CarsPictures
    {
        public long Id { get; set; }
        public Nullable<long> IdCars { get; set; }
        public string Picture { get; set; }
    
        public virtual Cars Cars { get; set; }
    }
}
