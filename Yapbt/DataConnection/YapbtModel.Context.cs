﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class YapbtDbEntities : DbContext
    {
        public YapbtDbEntities()
            : base("name=YapbtDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Airport> Airport { get; set; }
        public virtual DbSet<AirportPositions> AirportPositions { get; set; }
        public virtual DbSet<AirportPushBackPath> AirportPushBackPath { get; set; }
        public virtual DbSet<AirportPushPoints> AirportPushPoints { get; set; }
        public virtual DbSet<AirportVariations> AirportVariations { get; set; }
        public virtual DbSet<Configuration> Configuration { get; set; }
        public virtual DbSet<TempParking> TempParking { get; set; }
        public virtual DbSet<TempTaxiway> TempTaxiway { get; set; }
        public virtual DbSet<TempPoint> TempPoint { get; set; }
    }
}
