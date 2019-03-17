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

        public BusinessModels.SalesQuotation GetSalesQuotationDetails(Int32 identity)
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
                             .FirstOrDefault(p => p.Identity == identity );

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
                              .Where(p => p.IsActive == true && p.IsApproved == true && p.IsAssigned == true && p.StatusID != 6 && p.IsSend == false)
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
                             .Where(p => p.LocationID == locID && p.IsActive == true && p.IsApproved == true && p.IsAssigned == true && p.StatusID != 6 && p.IsSend == false)
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
                             .Where(p => p.LocationID == locID && p.AssignedTo == empID && p.IsActive == true && p.IsApproved == true && p.IsAssigned == true && p.StatusID != 6 && p.IsSend == false)
                            .ToList();
            }

            return _SalesQuotations;
        }

        public IEnumerable<BusinessModels.SalesQuotation> GetAllPendingSQForDispatch()
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
                              .Where(p => p.IsActive == true && p.IsApproved == true && p.IsAssigned == false && p.StatusID == 28 && p.IsSend == false)
                            .ToList();
            }

            return _SalesQuotations;
        }

        public IEnumerable<BusinessModels.SalesQuotation> GetAllPendingSQForDispatch(int locID)
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
                             .Where(p => p.LocationID == locID && p.IsActive == true && p.IsApproved == true && p.IsAssigned == false && p.StatusID == 28 && p.IsSend == false)
                            .ToList();
            }

            return _SalesQuotations;
        }

        public IEnumerable<BusinessModels.SalesQuotation> GetAllPendingSQForDispatch(int locID, int empID)
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
                             .Where(p => p.LocationID == locID && p.AssignedTo == empID && p.IsActive == true && p.IsApproved == true && p.IsAssigned == false && p.StatusID == 28 && p.IsSend == false)
                            .ToList();
            }

            return _SalesQuotations;
        }

        public IEnumerable<BusinessModels.SalesQuotation> GetAllSQForDispatch()
        {
            //coded
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
                              .Where(p => p.IsActive == true && p.IsApproved == true && p.IsAssigned == true && p.StatusID == 34 && p.IsSend == false)
                            .ToList();
            }

            return _SalesQuotations;
        }

        public IEnumerable<BusinessModels.SalesQuotation> GetAllSQForDispatch(int locID)
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
                             .Where(p => p.LocationID == locID && p.IsActive == true && p.IsApproved == true && p.IsAssigned == true && p.StatusID == 34 && p.IsSend == false)
                            .ToList();
            }

            return _SalesQuotations;
        }

        public IEnumerable<BusinessModels.SalesQuotation> GetAllSQForDispatch(int locID, int empID)
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
                             .Where(p => p.LocationID == locID && p.AssignedTo == empID && p.IsActive == true && p.IsApproved == true && p.IsAssigned == true && p.StatusID == 34 && p.IsSend == false)
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
                              .Where(p => p.IsActive == true && p.Status.Identity == 4 && p.IsApproved == true && p.IsAssigned==false)
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
                             .Where(p => p.LocationID == locID && p.IsActive == true && p.Status.Identity == 4 && p.IsApproved == true && p.IsAssigned == false)
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
                             .Where(p => p.LocationID == locID && p.CreatedBy == empID && p.IsActive == true && p.Status.Identity == 4 && p.IsApproved == true && p.IsAssigned == false)
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
                                .Where(p => (p != null && !string.IsNullOrEmpty(p.SQCode) && p.SQCode.Contains(prefix) && p.IsActive == true && p.IsApproved == true))
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

        public BusinessModels.SalesQuotation UpdateSalesQuotationAssignedandStatus(int? assignedid, int statusid, int identity)
        {
            var _user = new BusinessModels.SalesQuotation();
            try             {                 using (var dbContext = new SalesQuotationDbContext())                 {
                    _user = dbContext.Database.SqlQuery<BusinessModels.SalesQuotation>("CALL UpdateSQAssignedandStatus(@_id, @_assignedid,@_statusid)", new MySqlParameter("@_id", identity), new MySqlParameter("@_assignedid", assignedid), new MySqlParameter("@_statusid", statusid)).FirstOrDefault();                 }             }             catch (Exception ex)             {                 var test = ex.Message;             }
            return _user;
        }

        public BusinessModels.SalesQuotation UpdateSQSupervisorID(int? assignedid, int identity)
        {
            var _user = new BusinessModels.SalesQuotation();
            try             {                 using (var dbContext = new SalesQuotationDbContext())                 {
                    _user = dbContext.Database.SqlQuery<BusinessModels.SalesQuotation>("CALL UpdateSQSupervisorID(@_id, @_assignedid)", new MySqlParameter("@_id", identity), new MySqlParameter("@_assignedid", assignedid)).FirstOrDefault();                 }             }             catch (Exception ex)             {                 var test = ex.Message;             }
            return _user;
        }

       

        public BusinessModels.SalesQuotation UpdateSQDispatchFlag(bool flag, int? identity)
        {
            var _user = new BusinessModels.SalesQuotation();
            try             {                 using (var dbContext = new SalesQuotationDbContext())                 {
                    _user = dbContext.Database.SqlQuery<BusinessModels.SalesQuotation>("CALL UpdateSQDispatchFlag(@_id, @_flag)", new MySqlParameter("@_id", identity), new MySqlParameter("@_flag", flag)).FirstOrDefault();                 }             }             catch (Exception ex)             {                 var test = ex.Message;             }
            return _user;
        }

        public BusinessModels.SalesQuotation UpdateSalesQuotationAssigned(int? assignedid, int identity)
        {
            var _user = new BusinessModels.SalesQuotation();
            try             {                 using (var dbContext = new SalesQuotationDbContext())                 {
                    _user = dbContext.Database.SqlQuery<BusinessModels.SalesQuotation>("CALL UpdateSQAssignedID(@_id, @_assignedid)", new MySqlParameter("@_id", identity), new MySqlParameter("@_assignedid", assignedid)).FirstOrDefault();                 }             }             catch (Exception ex)             {                 var test = ex.Message;             }
            return _user;
        }

        public BusinessModels.SalesQuotation UpdateSalesQuotationStatus(int? statusid, int identity)
        {
            var _user = new BusinessModels.SalesQuotation();
            try             {                 //coded -- if status is invoice generated intiate Finance Manager and Finance head approval                 if(statusid==5)
                {


                }                 using (var dbContext = new SalesQuotationDbContext())                 {
                    _user = dbContext.Database.SqlQuery<BusinessModels.SalesQuotation>("CALL UpdateSQStatus(@_id, @_statusid)", new MySqlParameter("@_id", identity), new MySqlParameter("@_statusid", statusid)).FirstOrDefault();                 }             }             catch (Exception ex)             {                 var test = ex.Message;             }
            return _user;
        }

        public BusinessModels.SalesQuotation UpdateSalesQuotationApprovedFlag( int? identity, bool flag)
        {
            var _user = new BusinessModels.SalesQuotation();
            try             {                 using (var dbContext = new SalesQuotationDbContext())                 {
                    _user = dbContext.Database.SqlQuery<BusinessModels.SalesQuotation>("CALL UpdateSQApprovedFlag(@_flag,@_id)", new MySqlParameter("@_flag", flag), new MySqlParameter("@_id", identity)).FirstOrDefault();                 }             }             catch (Exception ex)             {                 var test = ex.Message;             }
            return _user;
        }

        public BusinessModels.SalesQuotation UpdateSalesQuotationAssignedFlag(int identity, bool flag)
        {
            var _user = new BusinessModels.SalesQuotation();
            try             {                 using (var dbContext = new SalesQuotationDbContext())                 {
                    _user = dbContext.Database.SqlQuery<BusinessModels.SalesQuotation>("CALL UpdateSQAssignedFlag(@_flag,@_id)", new MySqlParameter("@_flag", flag), new MySqlParameter("@_id", identity)).FirstOrDefault();                 }             }             catch (Exception ex)             {                 var test = ex.Message;             }
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
