﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GIBDD.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GIBDDEntities : DbContext
    {
        public GIBDDEntities()
            : base("name=GIBDDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Categorylicense> Categorylicense { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<DriverCars> DriverCars { get; set; }
        public virtual DbSet<Drivers> Drivers { get; set; }
        public virtual DbSet<Driving_license> Driving_license { get; set; }
        public virtual DbSet<Fine> Fine { get; set; }
        public virtual DbSet<FinesDriver> FinesDriver { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<MediaType> MediaType { get; set; }
        public virtual DbSet<Offence> Offence { get; set; }
        public virtual DbSet<OffencePunishment> OffencePunishment { get; set; }
        public virtual DbSet<Punishment> Punishment { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<typeFine> typeFine { get; set; }
        public virtual DbSet<TypeRequest> TypeRequest { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
