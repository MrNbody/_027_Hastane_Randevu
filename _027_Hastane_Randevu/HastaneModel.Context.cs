﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _027_Hastane_Randevu
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HastaneEntities : DbContext
    {
        public HastaneEntities()
            : base("name=HastaneEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Doktor> Doktors { get; set; }
        public virtual DbSet<Hastane> Hastanes { get; set; }
        public virtual DbSet<Ilce> Ilces { get; set; }
        public virtual DbSet<Klinik> Kliniks { get; set; }
        public virtual DbSet<Mesai> Mesais { get; set; }
        public virtual DbSet<Randevu> Randevus { get; set; }
        public virtual DbSet<Saat> Saats { get; set; }
        public virtual DbSet<Sehir> Sehirs { get; set; }
        public virtual DbSet<Uye> Uyes { get; set; }
        public virtual DbSet<viewDoktor> viewDoktors { get; set; }
        public virtual DbSet<viewRandevuDetay> viewRandevuDetays { get; set; }
    }
}
