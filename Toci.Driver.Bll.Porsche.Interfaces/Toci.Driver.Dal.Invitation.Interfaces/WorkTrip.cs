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
    
    public partial class WorkTrip
    {
        public long Id { get; set; }
        public Nullable<long> IdUser { get; set; }
        public Nullable<long> IdCityFrom { get; set; }
        public Nullable<long> IdCityTo { get; set; }
        public Nullable<decimal> FromLongitude { get; set; }
        public Nullable<decimal> FromLatitude { get; set; }
        public string FromStreet { get; set; }
        public Nullable<decimal> ToLongitude { get; set; }
        public Nullable<decimal> ToLatitude { get; set; }
        public string ToStreet { get; set; }
        public Nullable<decimal> FromHour { get; set; }
        public Nullable<decimal> ToHour { get; set; }
        public Nullable<decimal> AcceptableDistance { get; set; }
    
        public virtual City City { get; set; }
        public virtual City City1 { get; set; }
        public virtual Users Users { get; set; }
    }
}