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
    
    public partial class CarTypeDictionary
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarTypeDictionary()
        {
            this.Cars = new HashSet<Cars>();
        }
    
        public long Id { get; set; }
        public Nullable<long> IdCarDictionary { get; set; }
        public string CarType { get; set; }
    
        public virtual CarDictionary CarDictionary { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cars> Cars { get; set; }
    }
}