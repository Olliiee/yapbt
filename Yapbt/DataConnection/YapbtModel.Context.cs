﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
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
        public virtual DbSet<TempPoint> TempPoint { get; set; }
        public virtual DbSet<TempTaxiway> TempTaxiway { get; set; }
    }
}
