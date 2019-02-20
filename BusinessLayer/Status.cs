using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Status
    {
        private List<BusinessModels.Status> Statuss = new List<BusinessModels.Status>();
        private DataLayer.StatusDAL _dataLayer = null;

        public Status()
        {
            _dataLayer = new DataLayer.StatusDAL();
        }

        public BusinessModels.Status GetStatus(Int32 identity)
        {
            return _dataLayer.GetStatus(identity);
        }

        public IEnumerable<BusinessModels.Status> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.Status Status)
        {
            return _dataLayer.Update(Status);
        }

        public Boolean Insert(BusinessModels.Status Status)
        {
            return _dataLayer.Insert(Status);
        }



    }


}
