﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OSKManager
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OSKBazaEntities : DbContext
    {
        public OSKBazaEntities()
            : base("name=OSKBazaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Kursanci> Kursanci { get; set; }
        public virtual DbSet<Pojazdy> Pojazdy { get; set; }
        public virtual DbSet<Pracownicy> Pracownicy { get; set; }
    }
}
