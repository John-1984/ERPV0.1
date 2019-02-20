using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class StateDAL
    {
        private static List<BusinessModels.State> States = new List<BusinessModels.State>();

        public StateDAL()
        {
        }

        public BusinessModels.State GetState(Int32 identity)
        {
            var _State = new BusinessModels.State();
            using (var dbContext = new StateDbContext())
            {
                _State = dbContext.State
                            .Include("Region")
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _State;
        }

        public IEnumerable<BusinessModels.State> GetAll()
        {
            //Need to do
            var _States = new List<BusinessModels.State>();
            using (var dbContext = new StateDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _States = dbContext.State
                             .Include("Country")
                            .ToList();
            }

            return _States;
        }

        public IEnumerable<BusinessModels.Country> GetCountry()
        {
            var _Countrys = new List<BusinessModels.Country>();
            using (var dbContext = new CountryDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Countrys = dbContext.Country
                            .ToList();
            }
            return _Countrys;
        }

        public Boolean Update(BusinessModels.State State)
        {
            using (var dbContext = new StateDbContext())
            {
                dbContext.Entry(State).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new StateDbContext())
            {
                dbContext.Entry(new BusinessModels.State() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.State State)
        {
            using (var dbContext = new StateDbContext())
            {
                dbContext.Entry(State).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
