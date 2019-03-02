using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer
{
    public class OfficeExpenseDAL
    {
        private static List<BusinessModels.OfficeExpense> OfficeExpenses = new List<BusinessModels.OfficeExpense>();

        public OfficeExpenseDAL()
        {
        }

        public BusinessModels.OfficeExpense GetOfficeExpense(Int32 identity)
        {
            var _OfficeExpense = new BusinessModels.OfficeExpense();
            using (var dbContext = new OfficeExpenseDbContext())
            {
                _OfficeExpense = dbContext.OfficeExpense
                            .Include(K => K.Location)
                            .Include(o => o.CompanyType)
                            .Include(w => w.ExpenseType)
                            .Include(a => a.Employee)
                            .Include(d => d.Status)
                            .Include(e => e.Location.District)
                            .Include(r => r.Location.District.State)
                            .Include(t => t.Location.District.State.Country)
                            .Include(y => y.Location.District.State.Country.Region)
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _OfficeExpense;
        }

        public IEnumerable<BusinessModels.OfficeExpense> GetAll()
        {
            //Need to do
            var _OfficeExpenses = new List<BusinessModels.OfficeExpense>();
            using (var dbContext = new OfficeExpenseDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _OfficeExpenses = dbContext.OfficeExpense
                            .Include(K => K.Location)
                            .Include(o => o.CompanyType)
                            .Include(a => a.Employee)
                            .Include(d => d.Status)
                            .Include(w => w.ExpenseType)
                            .Include(e => e.Location.District)
                            .Include(r => r.Location.District.State)
                            .Include(t => t.Location.District.State.Country)
                            .Include(y => y.Location.District.State.Country.Region)
                            .ToList();
            }

            return _OfficeExpenses;
        }


    

        public IEnumerable<BusinessModels.OfficeExpense> GetAll(int locID)
        {
            var _OfficeExpenses = new List<BusinessModels.OfficeExpense>();
            using (var dbContext = new OfficeExpenseDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _OfficeExpenses = dbContext.OfficeExpense
                            .Include(K => K.Location)
                            .Include(o => o.CompanyType)
                            .Include(w => w.ExpenseType)
                            .Include(a => a.Employee)
                            .Include(d => d.Status)
                            .Include(e => e.Location.District)
                            .Include(r => r.Location.District.State)
                            .Include(t => t.Location.District.State.Country)
                            .Include(y => y.Location.District.State.Country.Region)
                             .Where(p => p.LocationID == locID && p.IsActive == true)
                            .ToList();
            }

            return _OfficeExpenses;
        }

        public IEnumerable<BusinessModels.OfficeExpense> GetAll(int locID, int empID)
        {
            var _OfficeExpenses = new List<BusinessModels.OfficeExpense>();
            using (var dbContext = new OfficeExpenseDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _OfficeExpenses = dbContext.OfficeExpense
                            .Include(K => K.Location)
                            .Include(o => o.CompanyType)
                            .Include(w => w.ExpenseType)
                            .Include(a => a.Employee)
                            .Include(d => d.Status)
                            .Include(e => e.Location.District)
                            .Include(r => r.Location.District.State)
                            .Include(t => t.Location.District.State.Country)
                            .Include(y => y.Location.District.State.Country.Region)

                             .Where(p => p.LocationID == locID && p.CreatedBy == empID && p.IsActive == true)
                            .ToList();
            }

            return _OfficeExpenses;
        }

        public IEnumerable<BusinessModels.OfficeExpense> GetMatchingOfficeExpenses(string prefix)
        {
            var _OfficeExpenses = new List<BusinessModels.OfficeExpense>();
            using (var dbContext = new OfficeExpenseDbContext())
            {
                try
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    _OfficeExpenses = dbContext.OfficeExpense
                        .Include(K => K.Location)
                            .Include(o => o.CompanyType)
                            .Include(w => w.ExpenseType)
                            .Include(a => a.Employee)
                            .Include(d => d.Status)
                            .Include(e => e.Location.District)
                            .Include(r => r.Location.District.State)
                            .Include(t => t.Location.District.State.Country)
                            .Include(y => y.Location.District.State.Country.Region)
                                .ToList()
                                .Where(p => (p != null && !string.IsNullOrEmpty(p.ExpenseType.TypeName) && p.ExpenseType.TypeName.Contains(prefix) && p.IsActive == true))
                                .ToList();
                }
                catch (Exception ex)
                {
                    var et = ex.Message;
                }
            }

            return _OfficeExpenses;
        }
        public Boolean Update(BusinessModels.OfficeExpense OfficeExpense)
        {
            using (var dbContext = new OfficeExpenseDbContext())
            {
                dbContext.Entry(OfficeExpense).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }
        
        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new OfficeExpenseDbContext())
            {
                dbContext.Entry(new BusinessModels.OfficeExpense() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.OfficeExpense OfficeExpense)
        {
            using (var dbContext = new OfficeExpenseDbContext())
            {
                dbContext.Entry(OfficeExpense).State= System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
