using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class VendorDAL
    {
        /// <summary>
        /// Multiple ways of calling EF
        ///     - Simple Query:
        ///         string sql = $@"select ID from User";
        ///         rowId = dbContext.Database.SqlQuery<int>(sql).ToList();
        ///     - Connected/Disconnected Way.
        ///         DisConnected way is used in this application
        ///     - Via Stored Procedures
        ///         Demonstarted in Login Module
        /// </summary>
        private static List<BusinessModels.Vendor> Vendors = new List<BusinessModels.Vendor>();

        public VendorDAL()
        {
        }

        public BusinessModels.Vendor GetVendor(Int32 identity)
        {
            var _Vendor = new BusinessModels.Vendor();
            using (var dbContext = new VendorDbContext())
            {
                _Vendor = dbContext.Vendor
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _Vendor;
        }

        public IEnumerable<BusinessModels.Vendor> GetAll()
        {
            var _Vendors = new List<BusinessModels.Vendor>();
            using (var dbContext = new VendorDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Vendors = dbContext.Vendor.ToList();
            }

            return _Vendors;
        }

        public Boolean Update(BusinessModels.Vendor Vendor)
        {
            using (var dbContext = new VendorDbContext())
            {
                dbContext.Entry(Vendor).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new VendorDbContext())
            {
                dbContext.Entry(new BusinessModels.Vendor() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.Vendor Vendor)
        {
            using (var dbContext = new VendorDbContext())
            {
                dbContext.Entry(Vendor).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
