﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BIIT_HRM_System.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HRMDB2Entities2 : DbContext
    {
        public HRMDB2Entities2()
            : base("name=HRMDB2Entities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Allow_Leave> Allow_Leave { get; set; }
        public virtual DbSet<Apply> Applies { get; set; }
        public virtual DbSet<Apply_Leave> Apply_Leave { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<job_posts> job_posts { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
    }
}
