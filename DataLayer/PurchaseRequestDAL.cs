using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class PurchaseRequestDAL
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
        private static List<BusinessModels.PurchaseRequest> PurchaseRequests = new List<BusinessModels.PurchaseRequest>();

        public PurchaseRequestDAL()
        {
        }

        public BusinessModels.PurchaseRequest GetPurchaseRequest(Int32? identity)
        {
            var _PurchaseRequest = new BusinessModels.PurchaseRequest();
            using (var dbContext = new PurchaseRequestDbContext())
            {
                _PurchaseRequest = dbContext.PurchaseRequest
                             .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseRequestType)
                             .Include(h => h.CompanyType)
                              .Include(w => w.EnquiryLevel)
                              .Where(p => p.IsActive == true)
                             .FirstOrDefault(p => p.Identity == identity);

                dbContext.Entry(_PurchaseRequest).Collection(p => p.PurchaseRequestDetails).Load();
            }
            return _PurchaseRequest;
        }

        

        public IEnumerable<BusinessModels.PurchaseRequest> GetAll()
        {
            var _PurchaseRequests = new List<BusinessModels.PurchaseRequest>();
            using (var dbContext = new PurchaseRequestDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseRequests = dbContext.PurchaseRequest
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseRequestType)
                             .Include(h => h.CompanyType)
                              .Include(w => w.EnquiryLevel)
                              .Where(p => p.IsActive == true)
                            .ToList();
            }

            return _PurchaseRequests;
        }

        public IEnumerable<BusinessModels.PurchaseRequest> GetAllPendingVerificationPR()
        {
            var _PurchaseRequests = new List<BusinessModels.PurchaseRequest>();
            using (var dbContext = new PurchaseRequestDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseRequests = dbContext.PurchaseRequest
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseRequestType)
                             .Include(h => h.CompanyType)
                              .Include(w => w.EnquiryLevel)
                              .Where(p => p.IsActive == true && p.Status.Identity == 15 && p.IsVerified == false)
                            .ToList();
            }

            return _PurchaseRequests;
        }

        public IEnumerable<BusinessModels.PurchaseRequest> GetAllPendingVerificationPR(int locID)
        {
            var _PurchaseRequests = new List<BusinessModels.PurchaseRequest>();
            using (var dbContext = new PurchaseRequestDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseRequests = dbContext.PurchaseRequest
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseRequestType)
                             .Include(h => h.CompanyType)
                              .Include(w => w.EnquiryLevel)
                             .Where(p => p.LocationID == locID && p.IsActive == true && p.POStatus == 15 && p.IsVerified == false)
                            .ToList();
            }

            return _PurchaseRequests;
        }

        public IEnumerable<BusinessModels.PurchaseRequest> GetAllPendingVerificationPR(int locID, int empID)
        {
            var _PurchaseRequests = new List<BusinessModels.PurchaseRequest>();
            using (var dbContext = new PurchaseRequestDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseRequests = dbContext.PurchaseRequest
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseRequestType)
                             .Include(h => h.CompanyType)
                              .Include(w => w.EnquiryLevel)
                             .Where(p => p.LocationID == locID && p.CreatedBy == empID && p.IsActive == true && p.Status.Identity == 15 && p.IsVerified == false)
                            .ToList();
            }

            return _PurchaseRequests;
        }

        public IEnumerable<BusinessModels.PurchaseRequest> GetAll(int locID)
        {
            var _PurchaseRequests = new List<BusinessModels.PurchaseRequest>();
            using (var dbContext = new PurchaseRequestDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseRequests = dbContext.PurchaseRequest
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseRequestType)
                             .Include(h => h.CompanyType)
                              .Include(w => w.EnquiryLevel)
                             .Where(p => p.LocationID == locID && p.IsActive == true)
                            .ToList();
            }

            return _PurchaseRequests;
        }

        public IEnumerable<BusinessModels.PurchaseRequest> GetAll(int locID, int empID)
        {
            var _PurchaseRequests = new List<BusinessModels.PurchaseRequest>();
            using (var dbContext = new PurchaseRequestDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseRequests = dbContext.PurchaseRequest
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseRequestType)
                             .Include(h => h.CompanyType)
                              .Include(w => w.EnquiryLevel)
                             .Where(p => p.LocationID == locID && p.CreatedBy == empID && p.IsActive == true)
                            .ToList();
            }

            return _PurchaseRequests;
        }

        public IEnumerable<BusinessModels.PurchaseRequest> GetMatchingPurchaseRequests(string prefix)
        {
            var _PurchaseRequests = new List<BusinessModels.PurchaseRequest>();
            using (var dbContext = new PurchaseRequestDbContext())
            {
                try
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    _PurchaseRequests = dbContext.PurchaseRequest
                        .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseRequestType)
                             .Include(h => h.CompanyType)
                              .Include(w => w.EnquiryLevel)
                                .ToList()
                                .Where(p => (p != null && !string.IsNullOrEmpty(p.CaseNo) && p.CaseNo.Contains(prefix) && p.IsActive == true))
                                .ToList();
                }
                catch (Exception ex)
                {
                    var et = ex.Message;
                }
            }

            return _PurchaseRequests;
        }

        public Boolean Update(BusinessModels.PurchaseRequest PurchaseRequest)
        {
            using (var dbContext = new PurchaseRequestDbContext())
            {
                dbContext.Entry(PurchaseRequest).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new PurchaseRequestDbContext())
            {
                dbContext.Entry(new BusinessModels.PurchaseRequest() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public BusinessModels.PurchaseRequest UpdatePurchaseRequestAssignedandStatus(int? assignedid, int statusid, int identity)
        {
            var _user = new BusinessModels.PurchaseRequest();
            try             {                 using (var dbContext = new UserDbContext())                 {
                    _user = dbContext.Database.SqlQuery<BusinessModels.PurchaseRequest>("CALL UpdatePRAssignedandStatus(@_id, @_assignedid,@_statusid)", new MySqlParameter("@_id", identity), new MySqlParameter("@_assignedid", assignedid), new MySqlParameter("@_statusid", statusid)).FirstOrDefault();                 }             }             catch (Exception ex)             {                 var test = ex.Message;             }
            return _user;
        }
        public BusinessModels.PurchaseRequest UpdatePurchaseRequestStatus(int statusid, int? identity)
        {
            var _user = new BusinessModels.PurchaseRequest();
            try             {                 using (var dbContext = new UserDbContext())                 {
                    _user = dbContext.Database.SqlQuery<BusinessModels.PurchaseRequest>("CALL UpdatePRStatus(@_id, @_statusid)", new MySqlParameter("@_id", identity),  new MySqlParameter("@_statusid", statusid)).FirstOrDefault();                 }             }             catch (Exception ex)             {                 var test = ex.Message;             }
            return _user;
        }
        public BusinessModels.PurchaseRequest UpdatePurchaseRequestApprovedFlag(int identity, bool flag)
        {
            var _user = new BusinessModels.PurchaseRequest();
            try             {                 using (var dbContext = new SalesQuotationDbContext())                 {
                    _user = dbContext.Database.SqlQuery<BusinessModels.PurchaseRequest>("CALL UpdatePRApprovedFlag(@_flag,@_id)", new MySqlParameter("@_flag", flag), new MySqlParameter("@_id", identity)).FirstOrDefault();                 }             }             catch (Exception ex)             {                 var test = ex.Message;             }
            return _user;
        }
        public BusinessModels.PurchaseRequest Insert(BusinessModels.PurchaseRequest PurchaseRequest)
        {
            using (var dbContext = new PurchaseRequestDbContext())
            {
                dbContext.Entry(PurchaseRequest).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return PurchaseRequest;
        }

    }
}
