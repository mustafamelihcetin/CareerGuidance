﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CareerGuidance.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CareerGuidanceEntities1 : DbContext
    {
        public CareerGuidanceEntities1()
            : base("name=CareerGuidanceEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Membership> Membership { get; set; }
        public virtual DbSet<Role_Authority> Role_Authority { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User_Role> User_Role { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
    }
}
