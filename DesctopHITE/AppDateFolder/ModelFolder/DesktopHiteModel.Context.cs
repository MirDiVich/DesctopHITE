﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DesctopHITE.AppDateFolder.ModelFolder
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DesctopHiteEntities : DbContext
    {
        public DesctopHiteEntities()
            : base("name=DesctopHiteEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<GenderTable> GenderTable { get; set; }
        public virtual DbSet<INNTable> INNTable { get; set; }
        public virtual DbSet<MedicalBookTable> MedicalBookTable { get; set; }
        public virtual DbSet<PassportTable> PassportTable { get; set; }
        public virtual DbSet<PlaceResidenceTable> PlaceResidenceTable { get; set; }
        public virtual DbSet<RoleTable> RoleTable { get; set; }
        public virtual DbSet<SalaryCardTable> SalaryCardTable { get; set; }
        public virtual DbSet<SnilsTable> SnilsTable { get; set; }
        public virtual DbSet<StatusTable> StatusTable { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<WorkerTabe> WorkerTabe { get; set; }
    }
}
