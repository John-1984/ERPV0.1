using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataLayer
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class PQAdvanceDetailsDbContext : DbContext
    {
        public PQAdvanceDetailsDbContext() : base("LocalMySqlServer")
        {
            var test = this.Database.Exists();
            this.Database.Connection.Open();
            this.Database.Connection.Close();
            var test1 = this.Database.Connection.ConnectionString;
        }

        public DbSet<BusinessModels.PQAdvanceDetails> PQAdvanceDetails { get; set; }
        public DbSet<BusinessModels.PurchaseQuotation> PurchaseQuotation { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}