using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataLayer
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class StocksDbContext : DbContext
    {
        public StocksDbContext() : base("LocalMySqlServer")
        {
            //var test = this.Database.Exists();
            //this.Database.Connection.Open();
            //this.Database.Connection.Close();
            //var test1 = this.Database.Connection.ConnectionString;
        }

        public DbSet<BusinessModels.Stocks> Stocks { get; set; }
        public DbSet<BusinessModels.Location> Location { get; set; }
        public DbSet<BusinessModels.ItemMaster> ItemMaster { get; set; }
        public DbSet<BusinessModels.CompanyType> CompanyType { get; set; }
      //  public DbSet<BusinessModels.StocksDetails> StocksDetails { get; set; }
        //public DbSet<Veri> Address { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<BusinessModels.Stocks>()
            //.HasMany(c => c.StocksDetails);
        }
    }
}
