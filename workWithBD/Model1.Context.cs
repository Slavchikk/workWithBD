﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace workWithBD
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Genders> Genders { get; set; }
        public virtual DbSet<Halls> Halls { get; set; }
        public virtual DbSet<halls_tickets> halls_tickets { get; set; }
        public virtual DbSet<Kinoteatr> Kinoteatr { get; set; }
        public virtual DbSet<Role_user> Role_user { get; set; }
        public virtual DbSet<sessions_days> sessions_days { get; set; }
        public virtual DbSet<sessions_time> sessions_time { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
        public virtual DbSet<type_halls> type_halls { get; set; }
        public virtual DbSet<type_tickets> type_tickets { get; set; }
        public virtual DbSet<users> users { get; set; }
    }
}