//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Org.Strausshome.Yapbt.DataConnection
{
    using System.Collections.Generic;

    public partial class AirportPositions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AirportPositions()
        {
            this.AirportPushBackPath = new HashSet<AirportPushBackPath>();
        }

        public System.Guid positionid { get; set; }
        public string positioname { get; set; }
        public double latitude { get; set; }
        public double longitutde { get; set; }
        public System.Guid variationid { get; set; }
        public System.DateTime cts { get; set; }

        public virtual AirportVariations AirportVariations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AirportPushBackPath> AirportPushBackPath { get; set; }
    }
}
