﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sanatorium.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class hrEntitysContainer : DbContext
    {
        public hrEntitysContainer()
            : base("name=hrEntitysContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<LoginLog> LoginLogs { get; set; }
        public virtual DbSet<RedHeadFile> RedHeadFiles { get; set; }
        public virtual DbSet<Sanatorium> Sanatoriums { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<Community> Communitys { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
    }
}
