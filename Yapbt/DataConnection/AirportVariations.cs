//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataConnection
{
    using System;
    using System.Collections.Generic;
    
    public partial class AirportVariations
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AirportVariations()
        {
            this.AirportPositions = new HashSet<AirportPositions>();
        }
    
        public System.Guid variationid { get; set; }
        public long airportid { get; set; }
        public string variationname { get; set; }
        public System.DateTime cts { get; set; }
    
        public virtual Airport Airport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AirportPositions> AirportPositions { get; set; }
    }
}
