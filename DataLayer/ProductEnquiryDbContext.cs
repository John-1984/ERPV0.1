using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataLayer
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class ProductEnquiryDbContext : DbContext
    {
        public ProductEnquiryDbContext() : base("LocalMySqlServer")
        {
            //var test = this.Database.Exists();
            //this.Database.Connection.Open();
            //this.Database.Connection.Close();
            //var test1 = this.Database.Connection.ConnectionString;
        }

        public DbSet<BusinessModels.ProductEnquiry> ProductEnquiry { get; set; }
        public DbSet<BusinessModels.Location> Location { get; set; }
        public DbSet<BusinessModels.Customer> Customer { get; set; }
        public DbSet<BusinessModels.Status> Status { get; set; }
        public DbSet<BusinessModels.EnquiryLevel> EnquiryLevel { get; set; }
        public DbSet<BusinessModels.Employee> Employee { get; set; }
        public DbSet<BusinessModels.ProductEnquiryDetails> ProductEnquiryDetails { get; set; }
        //public DbSet<Veri> Address { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<BusinessModels.ProductEnquiry>()
            //.HasMany(c => c.ProductEnquiryDetails);
        }
    }
}
