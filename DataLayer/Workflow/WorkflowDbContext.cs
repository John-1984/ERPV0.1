using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataLayer.Workflow
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class WorkflowDbContext : DbContext
    {
        public WorkflowDbContext() : base("LocalMySqlServer")
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<BusinessModels.Workflow.Workflow> Workflow { get; set; }
        public DbSet<BusinessModels.Workflow.Step> Step { get; set; }
        public DbSet<BusinessModels.Workflow.WorkflowStepMapping> WorkflowStepMapping { get; set; }
        public DbSet<BusinessModels.Workflow.ActiveWorkflow> ActiveWorkflow { get; set; }
        public DbSet<BusinessModels.Workflow.ActiveStep> ActiveStep { get; set; }
        public DbSet<BusinessModels.Location> Location { get; set; }
        public DbSet<BusinessModels.CompanyType> CompanyType { get; set; }
        public DbSet<BusinessModels.Company> Company { get; set; }
        public DbSet<BusinessModels.Menu> Menu { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}