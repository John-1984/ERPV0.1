using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
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
                            .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                            .Where(p => p.IsActive == true)
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _Employee;
        }

        //coded
        public BusinessModels.Employee GetStoreRoomManagerOnCompanyType(Int32 locidentity, int companyID, int companytype)
        {
            //coded
            var _Employee = new BusinessModels.Employee();
            using (var dbContext = new EmployeeDbContext())
            {
                _Employee = dbContext.Employee
                            .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                            .Where(p => p.IsActive == true  && p.CompanyID==companyID && p.CompanyTypeID==companytype && p.RoleMaster.RoleTypeID ==4 && p.RoleMaster.RoleName.Contains("Store Room Manager"))
                            .FirstOrDefault(p => p.LocationID==locidentity);
            }
            return _Employee;
        }

        public BusinessModels.Employee GetFinanceManagerOnCompanyType(Int32 locidentity, int companyID, int companytype)
        {
            //coded
            var _Employee = new BusinessModels.Employee();
            using (var dbContext = new EmployeeDbContext())
            {
                _Employee = dbContext.Employee
                            .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                            .Where(p => p.IsActive == true && p.CompanyID == companyID && p.CompanyTypeID == companytype && p.RoleMaster.RoleTypeID == 4 && p.RoleMaster.RoleName.Contains("Finance Manager"))
                            .FirstOrDefault(p => p.LocationID == locidentity);
            }
            return _Employee;
        }

        public BusinessModels.Employee GetFinanceManagerOnCompany(Int32 locidentity, int companyID)
        {
            //coded
            var _Employee = new BusinessModels.Employee();
            using (var dbContext = new EmployeeDbContext())
            {
                _Employee = dbContext.Employee
                            .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                            .Where(p => p.IsActive == true && p.CompanyID == companyID && p.RoleMaster.RoleTypeID == 4 && p.RoleMaster.RoleName.Contains("Finance Manager"))
                            .FirstOrDefault(p => p.LocationID == locidentity);
            }
            return _Employee;
        }

        public BusinessModels.Employee GetWareHouseManagerOnLocation(Int32 locidentity, int companyID)
        {
            //coded
            var _Employee = new BusinessModels.Employee();
            using (var dbContext = new EmployeeDbContext())
            {
                _Employee = dbContext.Employee
                            .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                            .Where(p => p.IsActive == true && p.CompanyID == companyID && p.RoleMaster.RoleTypeID == 4 && p.RoleMaster.RoleName.Contains("Warehouse Manager"))
                            .FirstOrDefault(p => p.LocationID == locidentity);
            }
            return _Employee;
        }

        

        public BusinessModels.Employee GetSupervisorOnWareHouseCompanyType(Int32 locidentity, int companyID, int companytype)
        {
            //coded
            var _Employee = new BusinessModels.Employee();
            using (var dbContext = new EmployeeDbContext())
            {
                _Employee = dbContext.Employee
                            .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                            .Where(p => p.IsActive == true && p.CompanyID == companyID && p.CompanyTypeID == companytype && p.RoleMaster.RoleTypeID == 12 && p.RoleMaster.RoleName.Contains("Warehouse Supervisor"))
                            .FirstOrDefault(p => p.LocationID == locidentity);
            }
            return _Employee;
        }

        public BusinessModels.Employee GetEmployeeLoginDetails(Int32 identity)
        {
            var _Employee = new BusinessModels.Employee();
            using (var dbContext = new EmployeeDbContext())
            {
                _Employee = dbContext.Employee
                            .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                            .Where(p=>p.IsActive == true)
                            .FirstOrDefault(p => p.Login.Identity.Equals(identity));
            }
            return _Employee;
        }
        public IEnumerable<BusinessModels.Employee> GetAllWareHouseManagerOnLocation(Int32 locidentity)
        {
            //coded
            var _Employee = new List<BusinessModels.Employee>();
            using (var dbContext = new EmployeeDbContext())
            {
                _Employee = dbContext.Employee
                            .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                            .Where(p => p.IsActive == true  && p.RoleMaster.RoleTypeID == 4 && p.RoleMaster.RoleName.Contains("Warehouse Incharge") && p.LocationID==locidentity)
                            .ToList();
            }
            return _Employee;
        }

        

        public IEnumerable<BusinessModels.Employee> GetAllWareHouseManagers()
        {
            //coded
            var _Employee = new List<BusinessModels.Employee>();
            using (var dbContext = new EmployeeDbContext())
            {
                _Employee = dbContext.Employee
                            .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                            .Where(p => p.IsActive == true && p.RoleMaster.RoleTypeID == 4 && p.RoleMaster.RoleName.Contains("Warehouse Manager"))
                            .ToList();
            }
            return _Employee;
        }

        public IEnumerable<BusinessModels.Employee> GetAllWareHouseSupervisors()
        {
            //coded
            var _Employee = new List<BusinessModels.Employee>();
            using (var dbContext = new EmployeeDbContext())
            {
                _Employee = dbContext.Employee
                            .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                            .Where(p => p.IsActive == true && p.RoleMaster.RoleTypeID == 12 && p.RoleMaster.RoleName.Contains("Warehouse Supervisor"))
                            .ToList();
            }
            return _Employee;
        }

        public IEnumerable<BusinessModels.Employee> GetAllWareHouseSupervisorsOnLocation(int locid)
        {
            //coded ----
            var _Employee = new List<BusinessModels.Employee>();
            using (var dbContext = new EmployeeDbContext())
            {
                _Employee = dbContext.Employee
                            .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                            .Where(p => p.IsActive == true && p.RoleMaster.RoleTypeID == 12 && p.RoleMaster.RoleName.Contains("Warehouse Supervisor") && p.LocationID==locid)
                            .ToList();
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
                             .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                            .Where(p=>p.IsActive == true
                            )
                            .ToList();
            }

            return _Employees;
        }


        public IEnumerable<BusinessModels.Employee> GetAllEmployeesOnRole(int fldidentity)
        {
            //Need to do
            var _Employees = new List<BusinessModels.Employee>();
            using (var dbContext = new EmployeeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Employees = dbContext.Employee
                             .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                             .Where(p => p.RoleMaster.Identity == fldidentity && p.IsActive == true)
                            .ToList();
            }

            return _Employees;
        }

        public IEnumerable<BusinessModels.Employee> GetAllEmployeesOnLocation(int fldidentity)
        {
            //Need to do
            var _Employees = new List<BusinessModels.Employee>();
            using (var dbContext = new EmployeeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Employees = dbContext.Employee
                             .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                             .Where(p => p.Location.Identity == fldidentity && p.IsActive == true)
                            .ToList();
            }

            return _Employees;
        }

        public IEnumerable<BusinessModels.Employee> GetAllEmployeesOnLocationByManager(int fldidentity)
        {
            //Need to do 
            //Coded
            var _Employees = new List<BusinessModels.Employee>();
            using (var dbContext = new EmployeeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Employees = dbContext.Employee
                             .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                             .Where(p => p.Location.Identity == fldidentity && p.IsActive == true )
                            .ToList();
            }

            _Employees =_Employees.Where(p=>p.RoleMaster.RoleTypeID <=4 ).ToList();
            return _Employees;
        }

        public IEnumerable<BusinessModels.Employee> GetAllFloorInchargeOnCompanyType(int? companytypeid,int fldidentity)
        {
            //Need to do
            var _Employees = new List<BusinessModels.Employee>();
            using (var dbContext = new EmployeeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Employees = dbContext.Employee
                             .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                             .Where(p => p.CompanyTypeID== companytypeid && p.RoleMaster.RoleTypeID==5 && p.LocationID==fldidentity && p.IsActive == true)
                            .ToList();
            }

            return _Employees;
        }

        public IEnumerable<BusinessModels.Employee> GetAllFinanceExecutivesOnCompanyType(int? companytypeid, int fldidentity)
        {
            //Need to do
            //coded
            var _Employees = new List<BusinessModels.Employee>();
            using (var dbContext = new EmployeeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Employees = dbContext.Employee
                             .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                             .Where(p => p.CompanyTypeID == companytypeid && p.RoleMaster.RoleTypeID == 6 && p.RoleMaster.RoleName.Contains("Finance Executive") && p.LocationID == fldidentity && p.IsActive == true)
                            .ToList();
            }

            return _Employees;
        }

        public IEnumerable<BusinessModels.Employee> GetAllWareHouseManagersOnCompany(int? companyid, int fldidentity)
        {
            //Need to do
            //coded
            var _Employees = new List<BusinessModels.Employee>();
            using (var dbContext = new EmployeeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Employees = dbContext.Employee
                             .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                             .Where(p => p.Company.Identity == companyid && p.RoleMaster.RoleTypeID == 4 && p.RoleMaster.RoleName.Contains("Warehouse Manager") && p.LocationID == fldidentity && p.IsActive == true)
                            .ToList();
            }

            return _Employees;
        }

        public BusinessModels.Employee GetPurchaseManagersOnCompany(int? companyid, int fldidentity)
        {
            //Need to do
            //coded
            var _Employees = new BusinessModels.Employee();
            using (var dbContext = new EmployeeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Employees = dbContext.Employee
                             .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                             .Where(p => p.Company.Identity == companyid && p.RoleMaster.RoleTypeID == 4 && p.RoleMaster.RoleName.Contains("Purchase Manager ") && p.LocationID == fldidentity && p.IsActive == true)
                            .FirstOrDefault();
            }

            return _Employees;
        }

        public IEnumerable<BusinessModels.Employee> GetWareHouseSupervisorsOnCompany(int? companyid, int fldidentity)
        {
            //Need to do
            //coded
            var _Employees = new List<BusinessModels.Employee>();
            using (var dbContext = new EmployeeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Employees = dbContext.Employee
                             .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                             .Where(p => p.Company.Identity == companyid && p.RoleMaster.RoleTypeID == 12 && p.RoleMaster.RoleName.Contains("Warehouse Supervisor") && p.LocationID == fldidentity && p.IsActive == true)
                            .ToList();
            }

            return _Employees;
        }

        public IEnumerable<BusinessModels.Employee> GetAllFloorExecutivesOnFloor(int? floorid, int fldidentity, int? companytypeid)
        {
            //Need to do
            var _Employees = new List<BusinessModels.Employee>();
            using (var dbContext = new EmployeeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Employees = dbContext.Employee
                             .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                             .Where(p => p.FloorMaster.Identity == floorid && p.IsActive == true && p.CompanyTypeID == companytypeid && p.RoleMaster.RoleTypeID == 6 && p.LocationID == fldidentity)
                            .ToList();
            }

            return _Employees;
        }

        public IEnumerable<BusinessModels.Employee> GetAllEmployeesOnCompanyType(int fldidentity)
        {
            //Need to do
            var _Employees = new List<BusinessModels.Employee>();
            using (var dbContext = new EmployeeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Employees = dbContext.Employee
                             .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                             .Where(p => p.CompanyType.Identity == fldidentity && p.IsActive == true)
                            .ToList();
            }

            return _Employees;
        }

        public IEnumerable<BusinessModels.Employee> GetAllEmployeesOnFloor(int fldidentity)
        {
            //Need to do
            var _Employees = new List<BusinessModels.Employee>();
            using (var dbContext = new EmployeeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Employees = dbContext.Employee
                             .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                             .Where(p => p.FloorMaster.Identity == fldidentity && p.IsActive == true)
                            .ToList();
            }

            return _Employees;
        }

        public IEnumerable<BusinessModels.Employee> GetAllEmployeesOnCompany(int fldidentity)
        {
            //Need to do
            var _Employees = new List<BusinessModels.Employee>();
            using (var dbContext = new EmployeeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Employees = dbContext.Employee
                             .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                             .Where(p => p.Company.Identity == fldidentity && p.IsActive == true)
                            .ToList();
            }

            return _Employees;
        }

        public IEnumerable<BusinessModels.Employee> GetAllEmployeesOnDistrict(int fldidentity)
        {
            //Need to do
            var _Employees = new List<BusinessModels.Employee>();
            using (var dbContext = new EmployeeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Employees = dbContext.Employee
                             .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                             .Where(p => p.Location.District.Identity == fldidentity && p.IsActive == true)
                            .ToList();
            }

            return _Employees;
        }

        public IEnumerable<BusinessModels.Employee> GetAllEmployeesOnState(int fldidentity)
        {
            //Need to do
            var _Employees = new List<BusinessModels.Employee>();
            using (var dbContext = new EmployeeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Employees = dbContext.Employee
                             .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                             .Where(p => p.Location.District.State.Identity == fldidentity && p.IsActive == true)
                            .ToList();
            }

            return _Employees;
        }

        public IEnumerable<BusinessModels.Employee> GetAllEmployeesOnCountry(int fldidentity)
        {
            //Need to do
            var _Employees = new List<BusinessModels.Employee>();
            using (var dbContext = new EmployeeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Employees = dbContext.Employee
                             .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                             .Where(p => p.Location.District.State.Country.Identity == fldidentity && p.IsActive == true)
                            .ToList();
            }

            return _Employees;
        }

        public IEnumerable<BusinessModels.Employee> GetAllEmployeesOnRegion(int fldidentity)
        {
            //Need to do
            var _Employees = new List<BusinessModels.Employee>();
            using (var dbContext = new EmployeeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Employees = dbContext.Employee
                             .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                             .Where(p => p.Location.District.State.Country.Region.Identity == fldidentity && p.IsActive == true)
                            .ToList();
            }

            return _Employees;
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

        public BusinessModels.Employee GetEmployeeLogin(Int32 identity)
        {
            var _Employee = new BusinessModels.Employee();
            using (var dbContext = new EmployeeDbContext())
            {
                _Employee = dbContext.Employee
                            .Include(K => K.RoleMaster)
                            .Include(l => l.Location)
                            .Include(o => o.CompanyType)
                            .Include(s => s.FloorMaster)
                            .Include(w => w.IdentificationsType)
                            .Include(q => q.Company)
                            .Include(a => a.Login)
                            .Include(x => x.RoleMaster.RoleType)
                            .Include(K => K.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                            .FirstOrDefault(p => p.Login.Identity.Equals(identity));
            }
            return _Employee;
        }

    }
}
