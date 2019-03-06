using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class SalesQuotationDAL
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
        private static List<BusinessModels.SalesQuotation> SalesQuotations = new List<BusinessModels.SalesQuotation>();

        public SalesQuotationDAL()
        {
        }

        public BusinessModels.SalesQuotation GetSalesQuotation(Int32 identity)
        {
            var _SalesQuotation = new BusinessModels.SalesQuotation();
            using (var dbContext = new SalesQuotationDbContext())
            {
                _SalesQuotation = dbContext.SalesQuotation
                             .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.ProductEnquiry)
                              .Include(w => w.EnquiryLevel)
                              .Include(l => l.CompanyType)
                              .Where(p => p.IsActive == true)
                             .FirstOrDefault(p => p.Identity == identity);

                dbContext.Entry(_SalesQuotation).Collection(p => p.ProductEnquiry.ProductEnquiryDetails).Load();
            }
            return _SalesQuotation;
        }

        

        public IEnumerable<BusinessModels.SalesQuotation> GetAll()
        {
            var _SalesQuotations = new List<BusinessModels.SalesQuotation>();
            using (var dbContext = new SalesQuotationDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _SalesQuotations = dbContext.SalesQuotation
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.ProductEnquiry)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                              .Where(p => p.IsActive == true)
                            .ToList();
            }

            return _SalesQuotations;
        }

        public IEnumerable<BusinessModels.SalesQuotation> GetAllPendingApporvalSQ()
        {
            var _SalesQuotations = new List<BusinessModels.SalesQuotation>();
            using (var dbContext = new SalesQuotationDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _SalesQuotations = dbContext.SalesQuotation
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.ProductEnquiry)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                              .Where(p => p.IsActive == true && p.Status.Identity == 15 && p.IsApproved == false)
                            .ToList();
            }

            return _SalesQuotations;
        }

        public IEnumerable<BusinessModels.SalesQuotation> GetAllPendingApporvalSQ(int locID)
        {
            var _SalesQuotations = new List<BusinessModels.SalesQuotation>();
            using (var dbContext = new SalesQuotationDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _SalesQuotations = dbContext.SalesQuotation
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.ProductEnquiry)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                             .Where(p => p.LocationID == locID && p.IsActive == true && p.StatusID == 15 && p.IsApproved == false)
                            .ToList();
            }

            return _SalesQuotations;
        }

        public IEnumerable<BusinessModels.SalesQuotation> GetAllPendingApporvalSQ(int locID, int empID)
        {
            var _SalesQuotations = new List<BusinessModels.SalesQuotation>();
            using (var dbContext = new SalesQuotationDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _SalesQuotations = dbContext.SalesQuotation
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.ProductEnquiry)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                             .Where(p => p.LocationID == locID && p.CreatedBy == empID && p.IsActive == true && p.Status.Identity == 15 && p.IsApproved == false)
                            .ToList();
            }

            return _SalesQuotations;
        }

        public IEnumerable<BusinessModels.SalesQuotation> GetAll(int locID)
        {
            var _SalesQuotations = new List<BusinessModels.SalesQuotation>();
            using (var dbContext = new SalesQuotationDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _SalesQuotations = dbContext.SalesQuotation
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.ProductEnquiry)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                             .Where(p => p.LocationID == locID && p.IsActive == true)
                            .ToList();
            }

            return _SalesQuotations;
        }

        public IEnumerable<BusinessModels.SalesQuotation> GetAll(int locID, int empID)
        {
            var _SalesQuotations = new List<BusinessModels.SalesQuotation>();
            using (var dbContext = new SalesQuotationDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _SalesQuotations = dbContext.SalesQuotation
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.ProductEnquiry)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                             .Where(p => p.LocationID == locID && p.CreatedBy == empID && p.IsActive == true)
                            .ToList();
            }

            return _SalesQuotations;
        }

        public IEnumerable<BusinessModels.SalesQuotation> GetMatchingSalesQuotations(string prefix)
        {
            var _SalesQuotations = new List<BusinessModels.SalesQuotation>();
            using (var dbContext = new SalesQuotationDbContext())
            {
                try
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    _SalesQuotations = dbContext.SalesQuotation
                        .Include(K => K.Location)
                             .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.ProductEnquiry)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                                .ToList()
                                .Where(p => (p != null && !string.IsNullOrEmpty(p.SQCode) && p.SQCode.Contains(prefix) && p.IsActive == true))
                                .ToList();
                }
                catch (Exception ex)
                {
                    var et = ex.Message;
                }
            }

            return _SalesQuotations;
        }

        public Boolean Update(BusinessModels.SalesQuotation SalesQuotation)
        {
            using (var dbContext = new SalesQuotationDbContext())
            {
                dbContext.Entry(SalesQuotation).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new SalesQuotationDbContext())
            {
                dbContext.Entry(new BusinessModels.SalesQuotation() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public bool UpdateSalesQuotationAssignedandStatus(int assignedid, int statusid, int identity)
        {
            var _user = false;
            try             {                 using (var dbContext = new UserDbContext())                 {
                    _user = dbContext.Database.SqlQuery<bool>("CALL UpdateSQAssignedandStatus(@_id, @_assignedid,@_statusid)", new MySqlParameter("@_id", identity), new MySqlParameter("@_assignedid", assignedid), new MySqlParameter("@_statusid", statusid)).FirstOrDefault();                 }             }             catch (Exception ex)             {                 var test = ex.Message;             }
            return _user;
        }

        public BusinessModels.SalesQuotation Insert(BusinessModels.SalesQuotation SalesQuotation)
        {
            using (var dbContext = new SalesQuotationDbContext())
            {
                dbContext.Entry(SalesQuotation).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return SalesQuotation;
        }

    }
}
