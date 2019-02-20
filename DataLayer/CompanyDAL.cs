using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CompanyDAL
    {
        private static List<BusinessModels.Company> Companys = new List<BusinessModels.Company>();

        public CompanyDAL()
        {
        }

        public BusinessModels.Company GetCompany(Int32 identity)
        {
            var _Company = new BusinessModels.Company();
            using (var dbContext = new CompanyDbContext())
            {
                _Company = dbContext.Company
                             .Include("Location")
                              .Include("CompanyType")
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _Company;
        }

        public IEnumerable<BusinessModels.Company> GetAll()
        {
            var _Companys = new List<BusinessModels.Company>();
            using (var dbContext = new CompanyDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Companys = dbContext.Company
                             .Include("Location")
                              .Include("CompanyType")
                            .ToList();
            }

            return _Companys;
        }

        public IEnumerable<BusinessModels.Location> GetLocations()
        {
            var _Locations = new List<BusinessModels.Location>();
            using (var dbContext = new LocationDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Locations = dbContext.Location
                            .ToList();
            }
            return _Locations;
        }

        public IEnumerable<BusinessModels.CompanyType> GetCompanyTypes()
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

        public IEnumerable<BusinessModels.Region> GetRegions()
        {
            var _Regions = new List<BusinessModels.Region>();
            using (var dbContext = new RegionDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Regions = dbContext.Region
                            .ToList();
            }
            return _Regions;
        }

        public IEnumerable<BusinessModels.Country> GetCountrys()
        {
            var _Countrys = new List<BusinessModels.Country>();
            using (var dbContext = new CountryDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Countrys = dbContext.Country
                            .ToList();
            }
            return _Countrys;
        }

        public IEnumerable<BusinessModels.State> GetStates()
        {
            var _States = new List<BusinessModels.State>();
            using (var dbContext = new StateDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _States = dbContext.State
                            .ToList();
            }
            return _States;
        }

        public IEnumerable<BusinessModels.District> GetDistricts()
        {
            var _Districts = new List<BusinessModels.District>();
            using (var dbContext = new DistrictDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Districts = dbContext.District
                            .ToList();
            }
            return _Districts;
        }

       

        public Boolean Update(BusinessModels.Company Company)
        {
            using (var dbContext = new CompanyDbContext())
            {
                dbContext.Entry(Company).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new CompanyDbContext())
            {
                dbContext.Entry(new BusinessModels.Company() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.Company Company)
        {
            using (var dbContext = new CompanyDbContext())
            {
                dbContext.Entry(Company).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
