using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class PurchaseOrderDAL
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
        private static List<BusinessModels.PurchaseOrder> PurchaseOrders = new List<BusinessModels.PurchaseOrder>();

        public PurchaseOrderDAL()
        {
        }

        public BusinessModels.PurchaseOrder GetPurchaseOrder(Int32 identity)
        {
            var _PurchaseOrder = new BusinessModels.PurchaseOrder();
            using (var dbContext = new PurchaseOrderDbContext())
            {
                _PurchaseOrder = dbContext.PurchaseOrder
                             .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseQuotation)
                              .Include(w => w.EnquiryLevel)
                              .Include(l => l.CompanyType)
                              .Where(p => p.IsActive == true)
                             .FirstOrDefault(p => p.Identity == identity);

               // dbContext.Entry(_PurchaseOrder).Collection(p => p.PurchaseRequest.PurchaseRequestDetails).Load();
            }
            return _PurchaseOrder;
        }

        public BusinessModels.PurchaseOrder GetPurchaseOrderDetails(Int32 identity)
        {
            var _PurchaseOrder = new BusinessModels.PurchaseOrder();
            using (var dbContext = new PurchaseOrderDbContext())
            {
                _PurchaseOrder = dbContext.PurchaseOrder
                             .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseQuotation)
                              .Include(w => w.EnquiryLevel)
                              .Include(l => l.CompanyType)
                              .Where(p => p.IsActive == true)
                             .FirstOrDefault(p => p.Identity == identity );

            }
            return _PurchaseOrder;
        }

        
        public IEnumerable<BusinessModels.PurchaseOrder> GetAllPendingApporvalPO()
        {
            var _PurchaseOrders = new List<BusinessModels.PurchaseOrder>();
            using (var dbContext = new PurchaseOrderDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseOrders = dbContext.PurchaseOrder
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseQuotation)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                              .Where(p => p.IsActive == true && p.Status.Identity == 4 )
                            .ToList();
            }

            return _PurchaseOrders;
        }

        public IEnumerable<BusinessModels.PurchaseOrder> GetAllPendingApporvalPO(int locID)
        {
            var _PurchaseOrders = new List<BusinessModels.PurchaseOrder>();
            using (var dbContext = new PurchaseOrderDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseOrders = dbContext.PurchaseOrder
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseQuotation)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                             .Where(p => p.LocationID == locID && p.IsActive == true && p.Status.Identity == 4)
                            .ToList();
            }

            return _PurchaseOrders;
        }

        public IEnumerable<BusinessModels.PurchaseOrder> GetAllPendingApporvalPO(int locID, int empID)
        {
            var _PurchaseOrders = new List<BusinessModels.PurchaseOrder>();
            using (var dbContext = new PurchaseOrderDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseOrders = dbContext.PurchaseOrder
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseQuotation)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                             .Where(p => p.LocationID == locID && p.CreatedBy == empID && p.IsActive == true && p.Status.Identity == 4 )
                            .ToList();
            }

            return _PurchaseOrders;
        }
        public IEnumerable<BusinessModels.PurchaseOrder> GetAll()
        {
            var _PurchaseOrders = new List<BusinessModels.PurchaseOrder>();
            using (var dbContext = new PurchaseOrderDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseOrders = dbContext.PurchaseOrder
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseQuotation)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                              .Where(p => p.IsActive == true && p.IsAssigned == false && p.IsWarehouseAssigned==false)
                            .ToList();
            }

            return _PurchaseOrders;
        }

        public IEnumerable<BusinessModels.PurchaseOrder> GetAll(int locID)
        {
            var _PurchaseOrders = new List<BusinessModels.PurchaseOrder>();
            using (var dbContext = new PurchaseOrderDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseOrders = dbContext.PurchaseOrder
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseQuotation)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                             .Where(p => p.LocationID == locID  && p.IsActive == true && p.IsAssigned == false && p.IsWarehouseAssigned == false)
                            .ToList();
            }

            return _PurchaseOrders;
        }

        public IEnumerable<BusinessModels.PurchaseOrder> GetAll(int locID, int empID)
        {
            var _PurchaseOrders = new List<BusinessModels.PurchaseOrder>();
            using (var dbContext = new PurchaseOrderDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseOrders = dbContext.PurchaseOrder
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseQuotation)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                             .Where(p => p.LocationID == locID && p.AssignedTo == empID && p.IsActive == true && p.IsAssigned == false && p.IsWarehouseAssigned == false)
                            .ToList();
            }

            return _PurchaseOrders;
        }


        public IEnumerable<BusinessModels.PurchaseOrder> GetAllPendingTobeAssigned()
        {
            var _PurchaseOrders = new List<BusinessModels.PurchaseOrder>();
            using (var dbContext = new PurchaseOrderDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseOrders = dbContext.PurchaseOrder
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseQuotation)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                              .Where(p => p.IsActive == true && p.IsAssigned == false && p.IsWarehouseAssigned == true)
                            .ToList();
            }

            return _PurchaseOrders;
        }

        public IEnumerable<BusinessModels.PurchaseOrder> GetAllPendingTobeAssigned(int locID)
        {
            var _PurchaseOrders = new List<BusinessModels.PurchaseOrder>();
            using (var dbContext = new PurchaseOrderDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseOrders = dbContext.PurchaseOrder
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseQuotation)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                             .Where(p => p.LocationID == locID && p.IsActive == true && p.IsAssigned == false && p.IsWarehouseAssigned == true)
                            .ToList();
            }

            return _PurchaseOrders;
        }

        public IEnumerable<BusinessModels.PurchaseOrder> GetAllPendingTobeAssigned(int locID, int empID)
        {
            var _PurchaseOrders = new List<BusinessModels.PurchaseOrder>();
            using (var dbContext = new PurchaseOrderDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseOrders = dbContext.PurchaseOrder
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseQuotation)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                             .Where(p => p.LocationID == locID && p.AssignedTo == empID && p.IsActive == true && p.IsAssigned == false && p.IsWarehouseAssigned == true)
                            .ToList();
            }

            return _PurchaseOrders;
        }

        public IEnumerable<BusinessModels.PurchaseOrder> GetAllWarehouseAssignedPO()
        {
            var _PurchaseOrders = new List<BusinessModels.PurchaseOrder>();
            using (var dbContext = new PurchaseOrderDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseOrders = dbContext.PurchaseOrder
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseQuotation)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                              .Where(p => p.IsActive == true && p.IsAssigned == true && p.IsWarehouseAssigned == true)
                            .ToList();
            }

            return _PurchaseOrders;
        }

        public IEnumerable<BusinessModels.PurchaseOrder> GetAllWarehouseAssignedPO(int locID)
        {
            var _PurchaseOrders = new List<BusinessModels.PurchaseOrder>();
            using (var dbContext = new PurchaseOrderDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseOrders = dbContext.PurchaseOrder
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseQuotation)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                             .Where(p => p.LocationID == locID && p.IsActive == true && p.IsAssigned == true && p.IsWarehouseAssigned == true)
                            .ToList();
            }

            return _PurchaseOrders;
        }

        public IEnumerable<BusinessModels.PurchaseOrder> GetAllWarehouseAssignedPO(int locID, int empID)
        {
            var _PurchaseOrders = new List<BusinessModels.PurchaseOrder>();
            using (var dbContext = new PurchaseOrderDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseOrders = dbContext.PurchaseOrder
                            .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseQuotation)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                             .Where(p => p.LocationID == locID && p.AssignedTo == empID && p.IsActive == true && p.IsAssigned == true && p.IsWarehouseAssigned == true)
                            .ToList();
            }

            return _PurchaseOrders;
        }



        public IEnumerable<BusinessModels.PurchaseOrder> GetMatchingPurchaseOrders(string prefix)
        {
            var _PurchaseOrders = new List<BusinessModels.PurchaseOrder>();
            using (var dbContext = new PurchaseOrderDbContext())
            {
                try
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    _PurchaseOrders = dbContext.PurchaseOrder
                        .Include(K => K.Location)
                             .Include(K => K.Location)
                             .Include(d => d.Employee)
                             .Include(f => f.Status)
                             .Include(g => g.PurchaseQuotation)
                              .Include(w => w.EnquiryLevel)
                               .Include(l => l.CompanyType)
                                .ToList()
                                .Where(p => (p != null && !string.IsNullOrEmpty(p.POCode) && p.POCode.Contains(prefix) && p.IsActive == true && p.IsApproved == true))
                                .ToList();
                }
                catch (Exception ex)
                {
                    var et = ex.Message;
                }
            }

            return _PurchaseOrders;
        }

        public Boolean Update(BusinessModels.PurchaseOrder PurchaseOrder)
        {
            using (var dbContext = new PurchaseOrderDbContext())
            {
                dbContext.Entry(PurchaseOrder).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new PurchaseOrderDbContext())
            {
                dbContext.Entry(new BusinessModels.PurchaseOrder() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public BusinessModels.PurchaseOrder UpdatePurchaseOrderAssignedandStatus(int? assignedid, int statusid, int identity)
        {
            var _user = new BusinessModels.PurchaseOrder();
            try             {                 using (var dbContext = new PurchaseOrderDbContext())                 {
                    _user = dbContext.Database.SqlQuery<BusinessModels.PurchaseOrder>("CALL UpdatePOAssignedandStatus(@_id, @_assignedid,@_statusid)", new MySqlParameter("@_id", identity), new MySqlParameter("@_assignedid", assignedid), new MySqlParameter("@_statusid", statusid)).FirstOrDefault();
                }             }             catch (Exception ex)             {                 var test = ex.Message;             }
            return _user;
        }

        public BusinessModels.PurchaseOrder UpdatePurchaseOrderAssigned(int? assignedid, int identity)
        {
            var _user = new BusinessModels.PurchaseOrder();
            try             {                 using (var dbContext = new PurchaseOrderDbContext())                 {
                     _user = dbContext.Database.SqlQuery<BusinessModels.PurchaseOrder>("CALL UpdatePOAssignedID(@_id, @_assignedid)", new MySqlParameter("@_id", identity), new MySqlParameter("@_assignedid", assignedid)).FirstOrDefault();
                }             }             catch (Exception ex)             {                 var test = ex.Message;             }
            return _user;
        }

        public BusinessModels.PurchaseOrder UpdatePOWareHouseAssignedID(int? assignedid, int identity)
        {
            var _user = new BusinessModels.PurchaseOrder();
            try             {                 using (var dbContext = new PurchaseOrderDbContext())                 {
                    _user = dbContext.Database.SqlQuery<BusinessModels.PurchaseOrder>("CALL UpdatePOWareHouseAssignedID(@_id, @_assignedid)", new MySqlParameter("@_id", identity), new MySqlParameter("@_assignedid", assignedid)).FirstOrDefault();
                }             }             catch (Exception ex)             {                 var test = ex.Message;             }
            return _user;
        }

        public BusinessModels.PurchaseOrder UpdatePurchaseOrderStatus(int? statusid, int identity)
        {
            var _user = new BusinessModels.PurchaseOrder();
            try             {                                 using (var dbContext = new PurchaseOrderDbContext())                 {
                     _user = dbContext.Database.SqlQuery<BusinessModels.PurchaseOrder>("CALL UpdatePOStatus(@_id, @_statusid)", new MySqlParameter("@_id", identity), new MySqlParameter("@_statusid", statusid)).FirstOrDefault();
                }             }             catch (Exception ex)             {                 var test = ex.Message;             }
            return _user;
        }

        public BusinessModels.PurchaseOrder UpdatePurchaseQuotationApprovedFlag( int identity, bool flag)
        {
            var _user = new BusinessModels.PurchaseOrder();
            try             {                 using (var dbContext = new PurchaseOrderDbContext())                 {
                    _user = dbContext.Database.SqlQuery<BusinessModels.PurchaseOrder>("CALL UpdatePOApprovedFlag(@_flag,@_id)", new MySqlParameter("@_flag", flag), new MySqlParameter("@_id", identity)).FirstOrDefault();                 }             }             catch (Exception ex)             {                 var test = ex.Message;             }
            return _user;
        }

        public BusinessModels.PurchaseOrder Insert(BusinessModels.PurchaseOrder PurchaseOrder)
        {
            using (var dbContext = new PurchaseOrderDbContext())
            {
                dbContext.Entry(PurchaseOrder).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return PurchaseOrder;
        }

    }
}
