using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
namespace DataLayer
{
    public class CustomerDAL
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
        private static List<BusinessModels.Customer> customers = new List<BusinessModels.Customer>();

        public CustomerDAL()
        {
        }

        public BusinessModels.Customer GetCustomer(Int32 identity)
        {
            var _customer = new BusinessModels.Customer();
            using (var dbContext = new CustomerDbContext())
            {
                _customer = dbContext.Customer
                             .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.Purpose)
                             .Include(h => h.EnquiryLevel)
                              .Where(p => p.IsActive == true)
                             .FirstOrDefault(p => p.Identity==identity);
            }
            return _customer;
        }

        public IEnumerable<BusinessModels.Customer> GetAll()
        {
            var _customers = new List<BusinessModels.Customer>();
            using (var dbContext = new CustomerDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _customers = dbContext.Customer
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.Purpose)
                              .Include(h => h.EnquiryLevel)
                              .Where(p => p.IsActive ==true)
                            .ToList();
            }

            return _customers;
        }

        public IEnumerable<BusinessModels.Customer> GetAll(int locID)
        {
            var _customers = new List<BusinessModels.Customer>();
            using (var dbContext = new CustomerDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _customers = dbContext.Customer
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.Purpose)
                              .Include(h => h.EnquiryLevel)
                             .Where(p => p.LocationID == locID && p.IsActive==true)
                            .ToList();
            }

            return _customers;
        }

        public IEnumerable<BusinessModels.Customer> GetAll(int locID, int empID)
        {
            var _customers = new List<BusinessModels.Customer>();
            using (var dbContext = new CustomerDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _customers = dbContext.Customer
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.Purpose)
                              .Include(h => h.EnquiryLevel)
                             .Where(p => p.LocationID == locID && p.CreatedBy== empID && p.IsActive == true)
                            .ToList();
            }

            return _customers;
        }

        public IEnumerable<BusinessModels.Customer> GetMatchingCustomers(string prefix)
        {
            var _customers = new List<BusinessModels.Customer>();
            using (var dbContext = new CustomerDbContext())
            {
                try
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    _customers = dbContext.Customer
                        .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.Purpose)
                              .Include(h => h.EnquiryLevel)
                                .ToList()
                                .Where(p => (p != null && !string.IsNullOrEmpty(p.CustomerName) && p.CustomerName.Contains(prefix) && p.IsActive == true))
                                .ToList();
                }
                catch (Exception ex)
                {
                    var et = ex.Message;
                }
            }

            return _customers;
        }

        public Boolean Update(BusinessModels.Customer customer) {
            using (var dbContext = new CustomerDbContext())
            {
                dbContext.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges(); 
            }
            return true;
        }

        public Boolean Delete(Int32 identity){
            using (var dbContext = new CustomerDbContext())
            {
                dbContext.Entry(new BusinessModels.Customer() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges(); 
            }
            return true;
        }

        public BusinessModels.Customer Insert(BusinessModels.Customer customer)
        {
            using (var dbContext = new CustomerDbContext())
            {
                dbContext.Entry(customer).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return customer;
        }

    }
}
