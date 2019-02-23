using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataLayer
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class TaxDbContext : DbContext
    {
        public TaxDbContext() : base("LocalMySqlServer")
        {
            //var test = this.Database.Exists();
            //this.Database.Connection.Open();
            //this.Database.Connection.Close();
            //var test1 = this.Database.Connection.ConnectionString;
        }

        public DbSet<BusinessModels.Tax> Tax { get; set; }
        public DbSet<BusinessModels.ItemMaster> ItemMaster { get; set; }
        public DbSet<BusinessModels.Brand> Brand { get; set; }
        public DbSet<BusinessModels.Vendor> Vendor { get; set; }
        public DbSet<BusinessModels.ProductMaster> ProductMaster { get; set; }
        //public DbSet<Veri> Address { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
