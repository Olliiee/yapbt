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
    
    public partial class AirportPushBackPath
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AirportPushBackPath()
        {
            this.AirportPushPoints = new HashSet<AirportPushPoints>();
        }
    
        public System.Guid pushbackpathid { get; set; }
        public string facing { get; set; }
        public System.Guid positionid { get; set; }
        public System.DateTime cts { get; set; }
    
        public virtual AirportPositions AirportPositions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AirportPushPoints> AirportPushPoints { get; set; }
    }
}