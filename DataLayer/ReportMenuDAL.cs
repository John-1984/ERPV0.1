using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DataLayer
{
    public class ReportMenuDAL
    {
        private static List<BusinessModels.ReportMenu> ReportMenus = new List<BusinessModels.ReportMenu>();

        public ReportMenuDAL()
        {
        }

        public BusinessModels.ReportMenu GetReportMenu(Int32 identity)
        {
            var _ReportMenu = new BusinessModels.ReportMenu();
            using (var dbContext = new ReportMenuDbContext())
            {
                _ReportMenu = dbContext.ReportMenu
                             .Include(K => K.SubModules)
                             .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _ReportMenu;
        }

        public IEnumerable<BusinessModels.ReportMenu> GetAll()
        {
            //Need to do
            var _ReportMenus = new List<BusinessModels.ReportMenu>();
            using (var dbContext = new ReportMenuDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _ReportMenus = dbContext.ReportMenu
                              .Include(K => K.SubModules)
                            .ToList();
            }

            return _ReportMenus;
        }

        public IEnumerable<BusinessModels.ReportMenu> GetAll(int bridentity)
        {
            //Need to do
            var _ReportMenus = new List<BusinessModels.ReportMenu>();
            using (var dbContext = new ReportMenuDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _ReportMenus = dbContext.ReportMenu
                             .Include(K => K.SubModules)
                            .Where(p => p.SubModules.Identity == bridentity)
                            .ToList();
            }

            return _ReportMenus;
        }

        public IEnumerable<BusinessModels.Vendor> GetVendor()
        {
            var _Vendors = new List<BusinessModels.Vendor>();
            using (var dbContext = new VendorDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Vendors = dbContext.Vendor
                            .ToList();
            }
            return _Vendors;
        }

        public Boolean Update(BusinessModels.ReportMenu ReportMenu)
        {
            using (var dbContext = new ReportMenuDbContext())
            {
                dbContext.Entry(ReportMenu).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new ReportMenuDbContext())
            {
                dbContext.Entry(new BusinessModels.ReportMenu() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.ReportMenu ReportMenu)
        {
            using (var dbContext = new ReportMenuDbContext())
            {
                dbContext.Entry(ReportMenu).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
