//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Org.Strausshome.Yapbt.DataConnection
{
    using System;
    using System.Collections.Generic;
    
    public partial class AirportPushPoints
    {
        public long id { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int heading { get; set; }
        public System.Guid pushbackpathid { get; set; }
    
        public virtual AirportPushBackPath AirportPushBackPath { get; set; }
    }
}
