using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EmployeeDAL
    {
        private static List<BusinessModels.Employee> Employees = new List<BusinessModels.Employee>();

        public EmployeeDAL()
        {
        }

        public BusinessModels.Employee GetEmployee(Int32 identity)
        {
            var _Employee = new BusinessModels.Employee();
            using (var dbContext = new EmployeeDbContext())
            {
                _Employee = dbContext.Employee
                            .Include("Company")
                            .Include("CompanyType")
                            .Include("IdentificationType")
                            .Include("Location")
                            .Include("RoleMaster")
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _Employee;
        }

        public IEnumerable<BusinessModels.Employee> GetAll()
        {
            //Need to do
            var _Employees = new List<BusinessModels.Employee>();
            using (var dbContext = new EmployeeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Employees = dbContext.Employee
                             .Include("Company")
                            .Include("CompanyType")
                            .Include("IdentificationType")
                            .Include("Location")
                            .Include("RoleMaster")
                            .ToList();
            }

            return _Employees;
        }

        public IEnumerable<BusinessModels.RoleMaster> GetAllRoles()
        {
            var _RoleMasters = new List<BusinessModels.RoleMaster>();
            using (var dbContext = new RoleMasterDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _RoleMasters = dbContext.RoleMaster
                            .ToList();
            }
            return _RoleMasters;
        }

        public IEnumerable<BusinessModels.Location> GetAllLocations()
        {
            var _Locationss = new List<BusinessModels.Location>();
            using (var dbContext = new LocationDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Locationss = dbContext.Location
                            .ToList();
            }
            return _Locationss;
        }

        public IEnumerable<BusinessModels.IdentificationsType> GetAllIdentificationTypes()
        {
            var _IdentificationTypes = new List<BusinessModels.IdentificationsType>();
            using (var dbContext = new IdentificationsTypeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _IdentificationTypes = dbContext.IdentificationsType
                            .ToList();
            }
            return _IdentificationTypes;
        }

        public IEnumerable<BusinessModels.CompanyType> GetAllCompanyType()
        {
            var _CompanyTypes = new List<BusinessModels.CompanyType>();
            using (var dbContext = new CompanyTypeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _CompanyTypes = dbContext.CompanyType
                            .ToList();
            }
            return _CompanyTypes;
        }
        public IEnumerable<BusinessModels.Company> GetAllCompanies()
        {
            var _Companiess = new List<BusinessModels.Company>();
            using (var dbContext = new CompanyDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Companiess = dbContext.Company
                            .ToList();
            }
            return _Companiess;
        }

        public Boolean Update(BusinessModels.Employee Employee)
        {
            using (var dbContext = new EmployeeDbContext())
            {
                dbContext.Entry(Employee).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new EmployeeDbContext())
            {
                dbContext.Entry(new BusinessModels.Employee() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.Employee Employee)
        {
            using (var dbContext = new EmployeeDbContext())
            {
                dbContext.Entry(Employee).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
