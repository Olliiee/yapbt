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

    public partial class Airport
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Airport()
        {
            this.AirportVariations = new HashSet<AirportVariations>();
        }

        public long airportid { get; set; }
        public string name { get; set; }
        public string icao { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AirportVariations> AirportVariations { get; set; }
    }
}
