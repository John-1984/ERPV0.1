﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataLayer
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class UOMMasterDbContext : DbContext
    {
        public UOMMasterDbContext() : base("LocalMySqlServer")
        {
            var test = this.Database.Exists();
            this.Database.Connection.Open();
            this.Database.Connection.Close();
            var test1 = this.Database.Connection.ConnectionString;
        }

        public DbSet<BusinessModels.UOMMaster> UOMMaster { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}