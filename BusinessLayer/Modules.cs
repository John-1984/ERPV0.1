using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Modules
    {
        private List<BusinessModels.Modules> Moduless = new List<BusinessModels.Modules>();
        private DataLayer.ModulesDAL _dataLayer = null;

        public Modules()
        {
            _dataLayer = new DataLayer.ModulesDAL();
        }

        public BusinessModels.Modules GetModules(Int32 identity)
        {
            return _dataLayer.GetModules(identity);
        }

        public IEnumerable<BusinessModels.Modules> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.Modules Modules)
        {
            return _dataLayer.Update(Modules);
        }

        public Boolean Insert(BusinessModels.Modules Modules)
        {
            return _dataLayer.Insert(Modules);
        }



    }


}
