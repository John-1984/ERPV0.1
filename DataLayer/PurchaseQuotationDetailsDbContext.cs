using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataLayer
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class PurchaseQuotationDetailsDbContext : DbContext
    {
        public PurchaseQuotationDetailsDbContext() : base("LocalMySqlServer")
        {
            //var test = this.Database.Exists();
            //this.Database.Connection.Open();
            //this.Database.Connection.Close();
            //var test1 = this.Database.Connection.ConnectionString;
        }

        public DbSet<BusinessModels.PurchaseQuotationDetails> PurchaseQuotationDetails { get; set; }
        public DbSet<BusinessModels.PurchaseQuotation> PurchaseQuotation { get; set; }
        //public DbSet<BusinessModels.ItemMaster> ItemMaster { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
