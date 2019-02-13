using System;
using System.Collections.Generic;
using System.Linq;

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
                            .Include("Address")
                            .FirstOrDefault(p => p.Identity.Equals(identity));
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
                            .Include("Address")
                            .ToList();
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

        public Boolean Insert(BusinessModels.Customer customer)
        {
            using (var dbContext = new CustomerDbContext())
            {
                dbContext.Entry(customer).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
