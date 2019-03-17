using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;
//using System.Data.Entity.
namespace DataLayer
{
    public class StocksDAL
    {
        private static List<BusinessModels.Stocks> Stockss = new List<BusinessModels.Stocks>();

        public StocksDAL()
        {
        }

        public BusinessModels.Stocks GetStocks(Int32 identity)
        {
            var _Stocks = new BusinessModels.Stocks();
            using (var dbContext = new StocksDbContext())
            {
                _Stocks = dbContext.Stocks
                             .Include(K => K.Location)
                             .Include(l => l.CompanyType)
                             .Include(l => l.ItemMaster)
                             .Include(e => e.ItemMaster.Brand)
                             .Include(e => e.ItemMaster.Brand.Vendor)
                            .Include(r => r.ItemMaster.Brand.Vendor.ProductMaster)
                            .Where(o=>o.IsActive==true)
                            .FirstOrDefault(p => p.Identity.Equals(identity));

               
            }
            return _Stocks;
        }

        public BusinessModels.Stocks GetStocks(int itemid, string size)
        {
            var _Stocks = new BusinessModels.Stocks();
            using (var dbContext = new StocksDbContext())
            {
                _Stocks = dbContext.Stocks
                             .Include(K => K.Location)
                             .Include(l => l.CompanyType)
                             .Include(l => l.ItemMaster)
                             .Include(e => e.ItemMaster.Brand)
                             .Include(e => e.ItemMaster.Brand.Vendor)
                            .Include(r => r.ItemMaster.Brand.Vendor.ProductMaster)
                            .Where(o => o.IsActive == true && o.ItemID == itemid && o.Size == size)
                            .FirstOrDefault();


            }
            return _Stocks;
        }

        public BusinessModels.Stocks GetStocksWithItemIDAndSize(Int32 identity,string size)
        {
            var _Stocks = new BusinessModels.Stocks();
            using (var dbContext = new StocksDbContext())
            {
                _Stocks = dbContext.Stocks
                             .Include(K => K.Location)
                             .Include(l => l.CompanyType)
                             .Include(l => l.ItemMaster)
                             .Include(e => e.ItemMaster.Brand)
                             .Include(e => e.ItemMaster.Brand.Vendor)
                            .Include(r => r.ItemMaster.Brand.Vendor.ProductMaster)
                             .Where(p=>p.Size==size && p.IsActive==true)
                            .FirstOrDefault(p => p.ItemID.Equals(identity));


            }
            return _Stocks;
        }

        public IEnumerable<BusinessModels.Stocks> GetAll()
        {
            //Need to do
            var _Stockss = new List<BusinessModels.Stocks>();
            using (var dbContext = new StocksDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Stockss = dbContext.Stocks
                             .Include(K => K.Location)
                             .Include(l => l.CompanyType)
                             .Include(l => l.ItemMaster)
                             .Include(e => e.ItemMaster.Brand)
                             .Include(e => e.ItemMaster.Brand.Vendor)
                            .Include(r => r.ItemMaster.Brand.Vendor.ProductMaster)
                            .Where(p=>p.IsActive==true)
                            .ToList();
            }

            return _Stockss;
        }     

        public IEnumerable<BusinessModels.Stocks> GetAll(int locID)
        {
            //Need to do
            var _Stockss = new List<BusinessModels.Stocks>();
            using (var dbContext = new StocksDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Stockss = dbContext.Stocks
                             .Include(K => K.Location)
                             .Include(l => l.CompanyType)
                             .Include(l => l.ItemMaster)
                             .Include(e => e.ItemMaster.Brand)
                             .Include(e => e.ItemMaster.Brand.Vendor)
                            .Include(r => r.ItemMaster.Brand.Vendor.ProductMaster)
                             .Where(p => p.Location.Identity == locID && p.IsActive == true)
                            .ToList();
            }

            return _Stockss;
        }

        public IEnumerable<BusinessModels.Stocks> GetAll(int locID, int empID)
        {
            //Need to do
            var _Stockss = new List<BusinessModels.Stocks>();
            using (var dbContext = new StocksDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Stockss = dbContext.Stocks
                              .Include(K => K.Location)
                             .Include(l => l.CompanyType)
                             .Include(l => l.ItemMaster)
                             .Include(e => e.ItemMaster.Brand)
                             .Include(e => e.ItemMaster.Brand.Vendor)
                            .Include(r => r.ItemMaster.Brand.Vendor.ProductMaster)
                             .Where(p => p.Location.Identity == locID && p.CreatedBy == empID && p.IsActive == true)
                            .ToList();
            }

            return _Stockss;
        }

        public IEnumerable<BusinessModels.Stocks> GetAllStocksShortage()
        {
            //Need to do
            var _Stockss = new List<BusinessModels.Stocks>();
            using (var dbContext = new StocksDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Stockss = dbContext.Stocks
                             .Include(K => K.Location)
                             .Include(l => l.CompanyType)
                             .Include(l => l.ItemMaster)
                             .Include(e => e.ItemMaster.Brand)
                             .Include(e => e.ItemMaster.Brand.Vendor)
                            .Include(r => r.ItemMaster.Brand.Vendor.ProductMaster)
                            .Where(p => p.IsActive == true && p.Quantity<100)
                            .ToList();
            }

            return _Stockss;
        }

        public IEnumerable<BusinessModels.Stocks> GetAllStockShortage(int locID)
        {
            //Need to do
            var _Stockss = new List<BusinessModels.Stocks>();
            using (var dbContext = new StocksDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Stockss = dbContext.Stocks
                             .Include(K => K.Location)
                             .Include(l => l.CompanyType)
                             .Include(l => l.ItemMaster)
                             .Include(e => e.ItemMaster.Brand)
                             .Include(e => e.ItemMaster.Brand.Vendor)
                            .Include(r => r.ItemMaster.Brand.Vendor.ProductMaster)
                             .Where(p => p.Location.Identity == locID && p.IsActive == true && p.Quantity < 100)
                            .ToList();
            }

            return _Stockss;
        }

        public IEnumerable<BusinessModels.Stocks> GetAllStocksShortage(int locID, int empID)
        {
            //Need to do
            var _Stockss = new List<BusinessModels.Stocks>();
            using (var dbContext = new StocksDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Stockss = dbContext.Stocks
                              .Include(K => K.Location)
                             .Include(l => l.CompanyType)
                             .Include(l => l.ItemMaster)
                             .Include(e => e.ItemMaster.Brand)
                             .Include(e => e.ItemMaster.Brand.Vendor)
                            .Include(r => r.ItemMaster.Brand.Vendor.ProductMaster)
                             .Where(p => p.Location.Identity == locID && p.CreatedBy == empID && p.IsActive == true && p.Quantity < 100)
                            .ToList();
            }

            return _Stockss;
        }


        public IEnumerable<BusinessModels.Stocks> GetAllDeadStock()
        {
            //Need to do
            DateTime dtNow = DateTime.Now;
            DateTime dtDead = DateTime.Now.AddDays(-100);

            var _Stockss = new List<BusinessModels.Stocks>();
            using (var dbContext = new StocksDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Stockss = dbContext.Stocks
                             .Include(K => K.Location)
                             .Include(l => l.CompanyType)
                             .Include(l => l.ItemMaster)
                             .Include(e => e.ItemMaster.Brand)
                             .Include(e => e.ItemMaster.Brand.Vendor)
                            .Include(r => r.ItemMaster.Brand.Vendor.ProductMaster)
                            .Where(p => p.IsActive == true && p.Quantity < 100 && p.ModifiedDate < dtDead)
                            .ToList();
            }

            return _Stockss;
        }

        public IEnumerable<BusinessModels.Stocks> GetAllDeadStock(int locID)
        {
            DateTime dtNow = DateTime.Now;
            DateTime dtDead = DateTime.Now.AddDays(-100);
            //Need to do
            var _Stockss = new List<BusinessModels.Stocks>();
            using (var dbContext = new StocksDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Stockss = dbContext.Stocks
                             .Include(K => K.Location)
                             .Include(l => l.CompanyType)
                             .Include(l => l.ItemMaster)
                             .Include(e => e.ItemMaster.Brand)
                             .Include(e => e.ItemMaster.Brand.Vendor)
                            .Include(r => r.ItemMaster.Brand.Vendor.ProductMaster)
                             .Where(p => p.Location.Identity == locID && p.IsActive == true && p.Quantity < 100 && p.ModifiedDate < dtDead)
                            .ToList();
            }

            return _Stockss;
        }

        public IEnumerable<BusinessModels.Stocks> GetAllDeadStock(int locID, int empID)
        {
            DateTime dtNow = DateTime.Now;
            DateTime dtDead = DateTime.Now.AddDays(-100);
            //Need to do
            var _Stockss = new List<BusinessModels.Stocks>();
            using (var dbContext = new StocksDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Stockss = dbContext.Stocks
                              .Include(K => K.Location)
                             .Include(l => l.CompanyType)
                             .Include(l => l.ItemMaster)
                             .Include(e => e.ItemMaster.Brand)
                             .Include(e => e.ItemMaster.Brand.Vendor)
                            .Include(r => r.ItemMaster.Brand.Vendor.ProductMaster)
                             .Where(p => p.Location.Identity == locID && p.CreatedBy == empID && p.IsActive == true && p.Quantity < 100 && p.ModifiedDate < dtDead)
                            .ToList();
            }

            return _Stockss;
        }


        public Boolean Update(BusinessModels.Stocks Stocks)
        {
            using (var dbContext = new StocksDbContext())
            {
                dbContext.Entry(Stocks).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new StocksDbContext())
            {
                dbContext.Entry(new BusinessModels.Stocks() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public BusinessModels.Stocks Insert(BusinessModels.Stocks Stocks)
        {
            using (var dbContext = new StocksDbContext())
            {
                dbContext.Entry(Stocks).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return Stocks;
        }

        public bool UpdateItemStockQuantity(int itemid, string size,decimal quantity)
        {
            var _user = false;
            try             {                 using (var dbContext = new UserDbContext())                 {
                    _user = dbContext.Database.SqlQuery<bool>("CALL UpdateItemStockQuantity(@_id, @_itemquanity, @_itemsize)", new MySqlParameter("@_id", itemid), new MySqlParameter("@_itemqty", quantity), new MySqlParameter("@_itemsize", size)).FirstOrDefault();                 }             }             catch (Exception ex)             {                 var test = ex.Message;             }
            return _user;
        }

    }
}
