using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace DataLayer
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class OfficeExpenseDbContext : DbContext
    {
        public OfficeExpenseDbContext() : base("LocalMySqlServer")
        {
            //var test = this.Database.Exists();
            //this.Database.Connection.Open();
            //this.Database.Connection.Close();
            //var test1 = this.Database.Connection.ConnectionString;
        }

        public DbSet<BusinessModels.OfficeExpense> OfficeExpense { get; set; }
        public DbSet<BusinessModels.Location> Location { get; set; }
        public DbSet<BusinessModels.CompanyType> CompanyType { get; set; }
        public DbSet<BusinessModels.ExpenseType> ExpenseType { get; set; }
        public DbSet<BusinessModels.Employee> Employee { get; set; }
        public DbSet<BusinessModels.Status> Status { get; set; }
        public DbSet<BusinessModels.Region> Region { get; set; }
        public DbSet<BusinessModels.Country> Country{ get; set; }
        public DbSet<BusinessModels.State> State { get; set; }
        public DbSet<BusinessModels.District> District { get; set; }

        //public DbSet<Veri> Address { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
