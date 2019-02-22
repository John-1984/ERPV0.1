using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DataLayer
{
    public class CompanyTypeDAL
    {
        private static List<BusinessModels.CompanyType> CompanyTypes = new List<BusinessModels.CompanyType>();

        public CompanyTypeDAL()
        {
        }

        public BusinessModels.CompanyType GetCompanyType(Int32 identity)
        {
            var _CompanyType = new BusinessModels.CompanyType();
            using (var dbContext = new CompanyTypeDbContext())
            {
                _CompanyType = dbContext.CompanyType
                            .Include(K => K.Company)
                            .Include(K => K.Company.Location)
                             .Include(K => K.Company.Location.District)
                            .Include(o => o.Company.Location.District.State)
                            .Include(o => o.Company.Location.District.State.Country)
                            .Include(o => o.Company.Location.District.State.Country.Region)
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _CompanyType;
        }

        public IEnumerable<BusinessModels.CompanyType> GetAll()
        {
            var _CompanyTypes = new List<BusinessModels.CompanyType>();
            using (var dbContext = new CompanyTypeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _CompanyTypes = dbContext.CompanyType
                            .Include(K => K.Company)
                            .Include(K => K.Company.Location)
                             .Include(K => K.Company.Location.District)
                            .Include(o => o.Company.Location.District.State)
                            .Include(o => o.Company.Location.District.State.Country)
                            .Include(o => o.Company.Location.District.State.Country.Region)
                            .ToList();
            }

            return _CompanyTypes;
        }

        public IEnumerable<BusinessModels.CompanyType> GetAll(int stidentity)
        {
            var _CompanyTypes = new List<BusinessModels.CompanyType>();
            using (var dbContext = new CompanyTypeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _CompanyTypes = dbContext.CompanyType
                            .Include(K => K.Company)
                            .Include(K => K.Company.Location)
                             .Include(K => K.Company.Location.District)
                            .Include(o => o.Company.Location.District.State)
                            .Include(o => o.Company.Location.District.State.Country)
                            .Include(o => o.Company.Location.District.State.Country.Region)
                             .Where(p => p.Company.Identity == stidentity)
                            .ToList();
            }

            return _CompanyTypes;
        }

        public IEnumerable<BusinessModels.Company> GetCompany()
        {
            var _Companys = new List<BusinessModels.Company>();
            using (var dbContext = new CompanyDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Companys = dbContext.Company
                            .ToList();
            }
            return _Companys;
        }

        public Boolean Update(BusinessModels.CompanyType CompanyType)
        {
            using (var dbContext = new CompanyTypeDbContext())
            {
                dbContext.Entry(CompanyType).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new CompanyTypeDbContext())
            {
                dbContext.Entry(new BusinessModels.CompanyType() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.CompanyType CompanyType)
        {
            using (var dbContext = new CompanyTypeDbContext())
            {
                dbContext.Entry(CompanyType).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
