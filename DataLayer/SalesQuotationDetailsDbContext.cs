using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataLayer
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class SalesQuotationDetailsDbContext : DbContext
    {
        public SalesQuotationDetailsDbContext() : base("LocalMySqlServer")
        {
            //var test = this.Database.Exists();
            //this.Database.Connection.Open();
            //this.Database.Connection.Close();
            //var test1 = this.Database.Connection.ConnectionString;
        }

        public DbSet<BusinessModels.SalesQuotationDetails> SalesQuotationDetails { get; set; }
        public DbSet<BusinessModels.SalesQuotation> SalesQuotation { get; set; }
        //public DbSet<BusinessModels.ItemMaster> ItemMaster { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
