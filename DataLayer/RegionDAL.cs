using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class RegionDAL
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
        private static List<BusinessModels.Region> Regions = new List<BusinessModels.Region>();

        public RegionDAL()
        {
        }

        public BusinessModels.Region GetRegion(Int32 identity)
        {
            var _Region = new BusinessModels.Region();
            using (var dbContext = new RegionDbContext())
            {
                _Region = dbContext.Region                            
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _Region;
        }

        public IEnumerable<BusinessModels.Region> GetAll()
        {
            var _Regions = new List<BusinessModels.Region>();
            using (var dbContext = new RegionDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Regions = dbContext.Region.Where(p=>p.RegionName!="All" && p.IsActive==true).ToList();
            }

            return _Regions;
        }

        public IEnumerable<BusinessModels.Region> GetAbroadRegions()
        {
            var _Regions = new List<BusinessModels.Region>();
            using (var dbContext = new RegionDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Regions = dbContext.Region.Where(p => p.RegionName == "Abroad" && p.IsActive == true).ToList();
            }

            return _Regions;
        }
        public IEnumerable<BusinessModels.Region> GetMatchingRegions(string prefix)
        {
            var _regiosns = new List<BusinessModels.Region>();
            using (var dbContext = new RegionDbContext())
            {
                try
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    _regiosns = dbContext.Region                        
                                .ToList()
                                .Where(p => (p != null && !string.IsNullOrEmpty(p.RegionName) && p.RegionName.Contains(prefix) && p.IsActive == true))
                                .ToList();
                }
                catch (Exception ex)
                {
                    var et = ex.Message;
                }
            }

            return _regiosns;
        }
        public Boolean Update(BusinessModels.Region Region)
        {
            using (var dbContext = new RegionDbContext())
            {
                dbContext.Entry(Region).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new RegionDbContext())
            {
                dbContext.Entry(new BusinessModels.Region() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.Region Region)
        {
            using (var dbContext = new RegionDbContext())
            {
                dbContext.Entry(Region).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
