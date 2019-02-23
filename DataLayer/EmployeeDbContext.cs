using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataLayer
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext() : base("LocalMySqlServer")
        {
            //var test = this.Database.Exists();
            //this.Database.Connection.Open();
            //this.Database.Connection.Close();
            //var test1 = this.Database.Connection.ConnectionString;
        }

        public DbSet<BusinessModels.Employee> Employee { get; set; }
        public DbSet<BusinessModels.Company> Company { get; set; }
        public DbSet<BusinessModels.CompanyType> CompanyType { get; set; }
        public DbSet<BusinessModels.IdentificationsType> IdentificationType { get; set; }
        public DbSet<BusinessModels.Location> Location { get; set; }
        public DbSet<BusinessModels.RoleMaster> RoleMaster { get; set; }
        public DbSet<BusinessModels.FloorMaster> FloorMaster { get; set; }
        public DbSet<BusinessModels.Login> Login { get; set; }
        //public DbSet<Veri> Address { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
