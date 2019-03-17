using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class PurchaseQuotationDAL
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
        private static List<BusinessModels.PurchaseQuotation> PurchaseQuotations = new List<BusinessModels.PurchaseQuotation>();

        public PurchaseQuotationDAL()
        {
        }

        public BusinessModels.PurchaseQuotation GetPurchaseQuotation(Int32 identity)
        {
            var _PurchaseQuotation = new BusinessModels.PurchaseQuotation();
            using (var dbContext = new PurchaseQuotationDbContext())
            {
                _PurchaseQuotation = dbContext.PurchaseQuotation
                             .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseRequest)
                              .Include(w => w.EnquiryLevel)
                              .Include(l => l.CompanyType)
                              .Where(p => p.IsActive == true)
                             .FirstOrDefault(p => p.Identity == identity);

                dbContext.Entry(_PurchaseQuotation).Collection(p => p.PurchaseRequest.PurchaseRequestDetails).Load();
            }
            return _PurchaseQuotation;
        }

        public BusinessModels.PurchaseQuotation GetPurchaseQuotationDetails(Int32? identity)
        {
            var _PurchaseQuotation = new BusinessModels.PurchaseQuotation();
            using (var dbContext = new PurchaseQuotationDbContext())
            {
                _PurchaseQuotation = dbContext.PurchaseQuotation
                             .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseRequest)
                              .Include(w => w.EnquiryLevel)
                              .Include(l => l.CompanyType)
                              .Where(p => p.IsActive == true)
                             .FirstOrDefault(p => p.Identity == identity );

            }
            return _PurchaseQuotation;
        }

        public IEnumerable<BusinessModels.PurchaseQuotation> GetAll()
        {
            var _PurchaseQuotations = new List<BusinessModels.PurchaseQuotation>();
            using (var dbContext = new PurchaseQuotationDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseQuotations = dbContext.PurchaseQuotation
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseRequest)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                              .Where(p => p.IsActive == true  && p.IsAssigned == true && p.StatusID != 6 && p.IsPOGenerated == false)
                            .ToList();
            }

            return _PurchaseQuotations;
        }

        public IEnumerable<BusinessModels.PurchaseQuotation> GetAllPendingApporvalPQ()
        {
            var _PurchaseQuotations = new List<BusinessModels.PurchaseQuotation>();
            using (var dbContext = new PurchaseQuotationDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseQuotations = dbContext.PurchaseQuotation
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseRequest)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                              .Where(p => p.IsActive == true && p.Status.Identity == 4 && p.IsApproved == true && p.IsAssigned==false)
                            .ToList();
            }

            return _PurchaseQuotations;
        }

        public IEnumerable<BusinessModels.PurchaseQuotation> GetAllPendingApporvalPQ(int locID)
        {
            var _PurchaseQuotations = new List<BusinessModels.PurchaseQuotation>();
            using (var dbContext = new PurchaseQuotationDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseQuotations = dbContext.PurchaseQuotation
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseRequest)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                             .Where(p => p.LocationID == locID && p.IsActive == true && p.Status.Identity == 4 && p.IsApproved == false && p.IsAssigned == false)
                            .ToList();
            }

            return _PurchaseQuotations;
        }

        public IEnumerable<BusinessModels.PurchaseQuotation> GetAllPendingApporvalPQ(int locID, int empID)
        {
            var _PurchaseQuotations = new List<BusinessModels.PurchaseQuotation>();
            using (var dbContext = new PurchaseQuotationDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseQuotations = dbContext.PurchaseQuotation
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseRequest)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                             .Where(p => p.LocationID == locID && p.CreatedBy == empID && p.IsActive == true && p.Status.Identity == 4 && p.IsApproved == true && p.IsAssigned == false)
                            .ToList();
            }

            return _PurchaseQuotations;
        }

        public IEnumerable<BusinessModels.PurchaseQuotation> GetAll(int locID)
        {
            var _PurchaseQuotations = new List<BusinessModels.PurchaseQuotation>();
            using (var dbContext = new PurchaseQuotationDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseQuotations = dbContext.PurchaseQuotation
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseRequest)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                             .Where(p => p.LocationID == locID  && p.IsActive == true  && p.IsAssigned == true && p.StatusID != 6 && p.IsPOGenerated == false)
                            .ToList();
            }

            return _PurchaseQuotations;
        }

        public IEnumerable<BusinessModels.PurchaseQuotation> GetAll(int locID, int empID)
        {
            var _PurchaseQuotations = new List<BusinessModels.PurchaseQuotation>();
            using (var dbContext = new PurchaseQuotationDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseQuotations = dbContext.PurchaseQuotation
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseRequest)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                             .Where(p => p.LocationID == locID && p.AssignedTo == empID && p.IsActive == true  && p.IsAssigned == true && p.StatusID != 6 && p.IsPOGenerated==false)
                            .ToList();
            }

            return _PurchaseQuotations;
        }

        public IEnumerable<BusinessModels.PurchaseQuotation> GetMatchingPurchaseQuotations(string prefix)
        {
            var _PurchaseQuotations = new List<BusinessModels.PurchaseQuotation>();
            using (var dbContext = new PurchaseQuotationDbContext())
            {
                try
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    _PurchaseQuotations = dbContext.PurchaseQuotation
                        .Include(K => K.Location)
                             .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseRequest)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                                .ToList()
                                .Where(p => (p != null && !string.IsNullOrEmpty(p.PQCode) && p.PQCode.Contains(prefix) && p.IsActive == true && p.IsApproved == true))
                                .ToList();
                }
                catch (Exception ex)
                {
                    var et = ex.Message;
                }
            }

            return _PurchaseQuotations;
        }

        public Boolean Update(BusinessModels.PurchaseQuotation PurchaseQuotation)
        {
            using (var dbContext = new PurchaseQuotationDbContext())
            {
                dbContext.Entry(PurchaseQuotation).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new PurchaseQuotationDbContext())
            {
                dbContext.Entry(new BusinessModels.PurchaseQuotation() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public BusinessModels.PurchaseQuotation UpdatePurchaseQuotationAssignedandStatus(int? assignedid, int statusid, int identity)
        {
            var _user = new BusinessModels.PurchaseQuotation();
            try             {                 using (var dbContext = new PurchaseQuotationDbContext())                 {
                    _user = dbContext.Database.SqlQuery<BusinessModels.PurchaseQuotation>("CALL UpdatePQAssignedandStatus(@_id, @_assignedid,@_statusid)", new MySqlParameter("@_id", identity), new MySqlParameter("@_assignedid", assignedid), new MySqlParameter("@_statusid", statusid)).FirstOrDefault();                 }             }             catch (Exception ex)             {                 var test = ex.Message;             }
            return _user;
        }

        public BusinessModels.PurchaseQuotation UpdatePurchaseQuotationAssigned(int? assignedid, int identity)
        {
            var _user = new BusinessModels.PurchaseQuotation();
            try             {                 using (var dbContext = new PurchaseQuotationDbContext())                 {
                    _user = dbContext.Database.SqlQuery<BusinessModels.PurchaseQuotation>("CALL UpdatePQAssignedID(@_id, @_assignedid)", new MySqlParameter("@_id", identity), new MySqlParameter("@_assignedid", assignedid)).FirstOrDefault();                 }             }             catch (Exception ex)             {                 var test = ex.Message;             }
            return _user;
        }

        public BusinessModels.PurchaseQuotation UpdatePurchaseQuotationStatus(int? statusid, int identity)
        {
            var _user = new BusinessModels.PurchaseQuotation();
            try             {                 //coded -- if status is invoice generated intiate Finance Manager and Finance head approval                 if(statusid==5)
                {


                }                 using (var dbContext = new PurchaseQuotationDbContext())                 {
                    _user = dbContext.Database.SqlQuery<BusinessModels.PurchaseQuotation>("CALL UpdatePQStatus(@_id, @_statusid)", new MySqlParameter("@_id", identity), new MySqlParameter("@_statusid", statusid)).FirstOrDefault();                 }             }             catch (Exception ex)             {                 var test = ex.Message;             }
            return _user;
        }

        public BusinessModels.PurchaseQuotation UpdatePurchaseQuotationApprovedFlag( int identity, bool flag)
        {
            var _user = new BusinessModels.PurchaseQuotation();
            try             {                 using (var dbContext = new PurchaseQuotationDbContext())                 {
                    _user = dbContext.Database.SqlQuery<BusinessModels.PurchaseQuotation>("CALL UpdatePQApprovedFlag(@_flag,@_id)", new MySqlParameter("@_flag", flag), new MySqlParameter("@_id", identity)).FirstOrDefault();                 }             }             catch (Exception ex)             {                 var test = ex.Message;             }
            return _user;
        }

        public BusinessModels.PurchaseQuotation Insert(BusinessModels.PurchaseQuotation PurchaseQuotation)
        {
            using (var dbContext = new PurchaseQuotationDbContext())
            {
                dbContext.Entry(PurchaseQuotation).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return PurchaseQuotation;
        }

    }
}
