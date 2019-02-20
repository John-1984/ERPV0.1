using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace DataLayer
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class StateDbContext : DbContext
    {
        public StateDbContext() : base("LocalMySqlServer")
        {
            //var test = this.Database.Exists();
            //this.Database.Connection.Open();
            //this.Database.Connection.Close();
            //var test1 = this.Database.Connection.ConnectionString;
        }

        public DbSet<BusinessModels.State> State { get; set; }
        public DbSet<BusinessModels.Country> Country { get; set; }
        public DbSet<BusinessModels.Region> Region { get; set; }

        //public DbSet<Veri> Address { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
