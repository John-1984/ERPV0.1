﻿using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataLayer.Workflow
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class WorkflowDbContext : DbContext
    {
        public WorkflowDbContext() : base("LocalMySqlServer")
        {
        }

        public DbSet<BusinessModels.Workflow.Workflow> Workflow { get; set; }
        public DbSet<BusinessModels.Workflow.Step> Step { get; set; }
        public DbSet<BusinessModels.Workflow.WorkflowStepMapping> WorkflowStepMapping { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}